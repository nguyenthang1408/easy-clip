using Common.Constant;
using Lib;
using Lib.VoiceServices.ElevenLabs;
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Lib.VoiceServices.ElevenLabs.V1.Services;
using Lib.VoiceServices.GoogleTTS;
using LibCommon.Lib.Model.Package;
using ReviewMovie.Infrastructure.Project;
using ReviewMovie.Localization;
using ReviewMovie.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyClip.Services
{
    public class AudioConvertService
    {
        public async Task ConvertTextToSpeechBatchAsync(
            string modeLabel,
            Func<bool> isOtherRunning,
            Func<int[]> getTargetIndexes,
            Func<bool> getIsRunning,
            Action<bool> setIsRunning,
            Func<CancellationTokenSource> getCTS,
            Action<CancellationTokenSource> setCTS,
            Action<string> setTextAction,
            string startText,
            string cancelText,
            AudioConvertContextModel context)
        {
            // 1. Wrap toàn bộ logic nặng vào Task.Run để giải phóng UI thread!
            await Task.Run(async () =>
            {
                if (getIsRunning())
                {
                    getCTS()?.Cancel();
                    return;
                }

                // Nếu có batch khác đang chạy: chỉ thông báo (alert), return luôn
                if (isOtherRunning())
                {
                    context.ShowAlertCallback?.Invoke(
                        LanguageManager.Get(LangKeys.Svc_ConvertAlreadyRunning));
                    return;
                }

                var cts = new CancellationTokenSource();
                setCTS(cts);
                setIsRunning(true);
                setTextAction?.Invoke(cancelText);

                try
                {
                    int[] indices = getTargetIndexes?.Invoke() ?? Array.Empty<int>();
                    foreach (var index in indices)
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        try
                        {
                            await ConvertText2SpeechAsync(index, context, cts.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Callback đã được gọi trong ConvertText2SpeechAsync
                            throw;
                        }
                        catch
                        {
                            // Lỗi bất ngờ ngoài try/catch của ConvertText2SpeechAsync (hiếm)
                            string inputText = context.GetInputTextByIndex?.Invoke(index) ?? string.Empty;
                            context.UpdateRowCallback?.Invoke(index, "", LanguageManager.Get(LangKeys.Svc_ConvertError), inputText);
                            context.OnAfterRowConverted?.Invoke(index, "", LanguageManager.Get(LangKeys.Svc_ConvertError), inputText);
                            // Có thể log thêm lỗi ex nếu muốn
                        }
                        await Task.Delay(300, cts.Token);
                    }
                    context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_ConvertComplete, modeLabel), Color.Green);
                }
                catch (OperationCanceledException)
                {
                    context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_ConvertCancelled, modeLabel), Color.OrangeRed);
                }
                finally
                {
                    setIsRunning(false);
                    setCTS(null);
                    setTextAction?.Invoke(startText);
                }
            });
        }


        public async Task ConvertText2SpeechAsync(int index, AudioConvertContextModel context, CancellationToken token)
        {
            // Kiểm tra index hợp lệ
            if (index < 0 ||
                (context.AllInfoRender != null && index >= context.AllInfoRender.Count) ||
                context.GetInputTextByIndex == null)
                return;

            string inputText = context.GetInputTextByIndex(index) ?? string.Empty;
            string audioStatus = string.Empty;
            string requestID = string.Empty;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                audioStatus = LanguageManager.Get(LangKeys.Svc_NoContent);
                context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
                context.OnAfterRowConverted?.Invoke(index, "", audioStatus, inputText);
                return;
            }

            audioStatus = "Converting...";
            context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
            context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_ConvertingRow, index), Color.Green);

            try
            {
                // Gọi usage API trước khi convert (chỉ khi dùng T2Psoft)
                if (context.IsT2Psoft && context.ApiRequest != null)
                {
                    ApiResponse<TtsUsageResponse> apiResponse;
                    try
                    {
                        apiResponse = await context.ApiRequest.LogTtsUsageAsync(
                            context.AppCode,
                            context.ProductSlug,
                            inputText,
                            LibConst.TtsSourceApp);
                    }
                    catch (Exception ex)
                    {
                        audioStatus = LanguageManager.Get(LangKeys.Svc_ServerConnectionError);
                        context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
                        context.OnAfterRowConverted?.Invoke(index, "", audioStatus, inputText);
                        context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_UsageApiError, ex.Message), Color.OrangeRed);
                        return;
                    }

                    // Server trả error (VD: daily limit exceeded, code 4005)
                    if (apiResponse == null || apiResponse.Error || apiResponse.Data == null || !apiResponse.Data.Success)
                    {
                        string serverMsg = apiResponse?.Message ?? LanguageManager.Get(LangKeys.Svc_UnknownServerError);
                        audioStatus = LanguageManager.Get(LangKeys.Svc_QuotaExceeded);
                        context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
                        context.OnAfterRowConverted?.Invoke(index, "", audioStatus, inputText);

                        // Hiển thị trên lblstatus kèm tooltip chi tiết
                        if (context.SetStatusWithTooltipCallback != null)
                            context.SetStatusWithTooltipCallback.Invoke(serverMsg, Color.OrangeRed, serverMsg);
                        else
                            context.SetStatusCallback?.Invoke(serverMsg, Color.OrangeRed);
                        return;
                    }

                    // Callback cập nhật characterUsed/characterLimit + rotate key in-memory
                    context.OnTtsUsageUpdated?.Invoke(apiResponse.Data);
                }

                switch (context.ManualSelected)
                {
                    case ManualSelect.FptAI:
                        requestID = await new ApiFptAI().FptAIConvertText2SpeechAsync(
                            context.AppID, context.VoiceCode, context.SpeechRatio.ToString("0.0"), inputText.Replace("\"", " "));
                        break;

                    case ManualSelect.Elevenlab:
                        // Dùng VoiceSettings truyền từ context luôn, không cần map lại!
                        var elevenLabRequest = new TextToSpeechEndpoint(context.AppID);
                        var text2speechRequest = new TextToSpeechRequest
                        {
                            Text = inputText,
                            VoiceSettings = context.VoiceSetting // class đúng ElevenLabs
                        };
                        var convertResponse = await elevenLabRequest.SendTextToSpeechRequestAsync(
                            context.VoiceCode, text2speechRequest, OutputFormat.MP3_44100_32);
                        requestID = convertResponse?.HistoryItemId ?? string.Empty;
                        break;

                    case ManualSelect.Vbee:
                        requestID = await new ApiVbee().ConvertText2SpeechAsync(
                            context.AppID, context.Token, context.VoiceCode,
                            context.SpeechRatio.ToString("0.0"), inputText.Replace("\"", " "));
                        break;

                    case ManualSelect.Google:
                        string fullpath = $"{context.AudioTempPath}{index}.mp3";
                        var client = new APIGoogleTTS();
                        var result = client.ConvertTextToSpeech(
                            context.AppID, inputText.Replace("\"", " "),
                            context.VoiceCode, fullpath);
                        if (result.IsSuccess)
                            requestID = fullpath;
                        break;

                    default:
                        throw new NotSupportedException("Provider TTS chưa được hỗ trợ.");
                }

                if (!string.IsNullOrEmpty(requestID))
                {
                    audioStatus = "Converted";
                }
                else
                {
                    audioStatus = LanguageManager.Get(LangKeys.Svc_ConvertError);
                }
                context.UpdateRowCallback?.Invoke(index, requestID, audioStatus, inputText);
                context.OnAfterRowConverted?.Invoke(index, requestID, audioStatus, inputText);
            }
            catch (OperationCanceledException)
            {
                audioStatus = LanguageManager.Get(LangKeys.Main_Cancelled);
                context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
                context.OnAfterRowConverted?.Invoke(index, "", audioStatus, inputText);
                context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_CancelConvertRow, index), Color.OrangeRed);
                throw;
            }
            catch (Exception ex)
            {
                audioStatus = LanguageManager.Get(LangKeys.Svc_ConvertError);
                context.UpdateRowCallback?.Invoke(index, "", audioStatus, inputText);
                context.OnAfterRowConverted?.Invoke(index, "", audioStatus, inputText);
                context.SetStatusCallback?.Invoke(LanguageManager.GetFormat(LangKeys.Svc_ConvertRowError, index, ex.Message), Color.Red);
            }
        }

    }
}
