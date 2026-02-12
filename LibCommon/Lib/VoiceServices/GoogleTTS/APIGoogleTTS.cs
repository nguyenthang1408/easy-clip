using Google.Api.Gax.Grpc;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lib.VoiceServices.GoogleTTS
{
    public class ConversionResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ConversionResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
    public class APIGoogleTTS
    {
        public APIGoogleTTS() { }

        public TextToSpeechClient textToSpeechClient(string jsonData)
        {
            if (string.IsNullOrWhiteSpace(jsonData)) return null;

            try
            {
                // Kiểm tra xem jsonData có phải là JSON hợp lệ không (có thể thêm logic nếu cần)
                if (!jsonData.TrimStart().StartsWith("{"))
                {
                    //MessageBox.Show("Dữ liệu không đúng định dạng JSON.");
                    return null;
                }

                // Tạo GoogleCredential từ tệp JSON
                GoogleCredential credential = GoogleCredential.FromJson(jsonData);

                // Sử dụng TextToSpeechClientBuilder để cấu hình client
                var clientBuilder = new TextToSpeechClientBuilder
                {
                    ChannelCredentials = credential.ToChannelCredentials()
                };

                // Xây dựng TextToSpeechClient
                return clientBuilder.Build();
            }
            catch
            {
                //catch (Exception ex) {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Timeout cho gRPC calls tránh treo app khi mất mạng
        private static readonly CallSettings _callSettings = CallSettings.FromExpiration(
            Expiration.FromTimeout(NetworkConfig.Timeout));

        public ListVoicesResponse listVoicesResponse(TextToSpeechClient client)
        {
            return client?.ListVoices(new ListVoicesRequest(), _callSettings) ?? null;
        }

        public ConversionResult ConvertTextToSpeech(string jsonData, string textInput, string voiceCode, string savePath)
        {
            try
            {
                // Kiểm tra các tham số đầu vào
                if (string.IsNullOrEmpty(jsonData)) return new ConversionResult(false, "JSON Data không được để trống.");
                if (string.IsNullOrEmpty(textInput)) return new ConversionResult(false, "Nội dung chuyển đổi không được để trống.");
                if (string.IsNullOrEmpty(voiceCode)) return new ConversionResult(false, "Voice code không được để trống.");
                if (string.IsNullOrEmpty(savePath)) return new ConversionResult(false, "Đường dẫn lưu file không được để trống.");

                // Thiết lập Google Text-to-Speech client
                var client = textToSpeechClient(jsonData);

                // Cấu hình yêu cầu chuyển đổi
                var synthesisInput = new SynthesisInput
                {
                    Text = textInput
                };

                var voiceParams = new VoiceSelectionParams
                {
                    Name = voiceCode,
                    LanguageCode = GetLanguageCodeFromVoice(client, voiceCode) // Lấy mã ngôn ngữ từ giọng đọc
                };

                var audioConfig = new AudioConfig
                {
                    AudioEncoding = AudioEncoding.Mp3
                };

                // Gửi yêu cầu đến API và nhận phản hồi (timeout 7s)
                var response = client.SynthesizeSpeech(synthesisInput, voiceParams, audioConfig, _callSettings);

                // Kiểm tra dữ liệu âm thanh trả về
                if (response.AudioContent == null || response.AudioContent.Length == 0)
                    return new ConversionResult(false, "Không nhận được dữ liệu âm thanh từ API.");

                // Lưu file MP3
                File.WriteAllBytes(savePath, response.AudioContent.ToByteArray());

                return new ConversionResult(true, "Tải xuống thành công."); // Trạng thái tải xuống thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return new ConversionResult(false, $"Lỗi: {ex.Message}"); // Trạng thái tải xuống thất bại cùng với thông báo lỗi
            }
        }

        private string GetLanguageCodeFromVoice(TextToSpeechClient client, string voiceName)
        {
            var response = client.ListVoices(new ListVoicesRequest(), _callSettings);
            var voice = response.Voices.FirstOrDefault(v => v.Name == voiceName);
            return voice?.LanguageCodes.FirstOrDefault() ?? "en-US"; // Mặc định là tiếng Anh (Mỹ)
        }
    }
}
