using Lib;
using Lib.VoiceServices.ElevenLabs.V1.Services;
using ReviewMovie.Localization;
using ReviewMovie.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyClip.Services
{
    public interface IAudioDownloadService
    {
        Task DownloadAudioAsync(AudioDownloadContextModel context, bool recordStatus, CancellationToken token);
    }
    public class AudioDownloadService : IAudioDownloadService
    {
        public async Task DownloadAudioAsync(AudioDownloadContextModel ctx, bool recordStatus, CancellationToken token)
        {
            bool fdone = false;
            Random random = new Random();
            double minValue = (double)ctx.ScaleAudioRangeStart;
            double maxValue = (double)ctx.ScaleAudioRangeEnd;
            double randomValue = random.NextDouble();
            double scaledValue = minValue + (randomValue * (maxValue - minValue));

            var dataGridRowSelect = ctx.GetDataGridViewRow(ctx.RowIndex);
            var timevd = ctx.GetInfoRenderByRowIndex(ctx.RowIndex);
            var saveapath = Path.Combine(ctx.AudioPath, $"{ctx.RowIndex}.mp3");

            if (!string.IsNullOrEmpty(ctx.AddressLink))
            {
                if (recordStatus)
                {
                    await Task.Run(() => RecordAudio.RemoveNoise(ctx.AddressLink, saveapath));
                    //RecordAudio.RemoveNoise(ctx.AddressLink, saveapath);
                }
                else
                {
                    if (ctx.ManualSelected == ManualSelect.Elevenlab)
                    {
                        GetAudioInHistory getAudio = new GetAudioInHistory(ctx.AppId);
                        fdone = await getAudio.DownloadAudioAsync(ctx.AddressLink, saveapath);
                    }
                    else
                    {
                        var jobResult = await Funcion.DownloadFileAsync(new Iobject
                        {
                            uri = ctx.AddressLink,
                            savepath = ctx.AudioPath,
                            filename = $"{ctx.RowIndex}.mp3"
                        });
                        fdone = jobResult.ResultCode;
                    }
                }

                token.ThrowIfCancellationRequested();

                if ((fdone && File.Exists(saveapath)) || (recordStatus && File.Exists(saveapath)))
                {
                    //string valuetime = Funcion.GetMediaTime(saveapath);
                    string valuetime = await Task.Run(() => Funcion.GetMediaTime(saveapath));

                    decimal timeaudio = (decimal)(Convert.ToDouble(valuetime) / 1000);
                    string timestatus = $"{timeaudio:0.000}s";

                    string downloadstatus = timeaudio > 0
                        ? recordStatus
                            ? LanguageManager.GetFormat(LangKeys.Svc_RecordSuccess, $"{timeaudio:0.000}")
                            : LanguageManager.GetFormat(LangKeys.Svc_DownloadSuccess, $"{timeaudio:0.000}")
                        : recordStatus ? LanguageManager.Get(LangKeys.Svc_RecordFailed) : LanguageManager.Get(LangKeys.Svc_DownloadFailed);

                    if (timeaudio > 0)
                    {
                        var mediaType = CheckMedia.GetMediaType(dataGridRowSelect.Cells["Column_filemediapath"].Value?.ToString());

                        if (mediaType is MediaType.Picture)
                        {
                            if (timeaudio > 0)
                            {
                                decimal audioTimeScale = timeaudio * (decimal)scaledValue;
                                string audioTimeScalestatus = $"{audioTimeScale:0.000}s";
                                timevd.TimeOfMediaPart = audioTimeScale;
                                ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_timevideo", audioTimeScalestatus, Color.White);
                            }
                        }
                        else if (mediaType is MediaType.Video)
                        {
                            if (timeaudio > timevd.TimeOfMediaPart)
                            {
                                timevd.TimeOfMediaPart = timeaudio;
                                ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_timevideo", timestatus, Color.White);
                            }
                        }

                        ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_audioTime", timestatus, Color.White);
                        ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_audiostatus", downloadstatus, Color.GreenYellow);
                    }
                    else
                    {
                        ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_audiostatus", downloadstatus, Color.OrangeRed);
                    }

                    if (timevd != null) timevd.Audiotime = timeaudio;
                    ctx.UpdateAudioTimeCallback?.Invoke(ctx.RowIndex, timeaudio);
                }
                else
                {
                    ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_audiostatus", LanguageManager.Get(LangKeys.Svc_DownloadFailed), Color.OrangeRed);
                }
            }
            else
            {
                ctx.UpdateCellCallback?.Invoke(ctx.RowIndex, "Column_audiostatus", LanguageManager.Get(LangKeys.Svc_ConversionNotReady), Color.Orange);
            }
        }
    }


}
