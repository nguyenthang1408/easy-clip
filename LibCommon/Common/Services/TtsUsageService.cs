using LibCommon.Lib.Model.Package;
using System.Threading.Tasks;

namespace Common.Services
{
    public partial class ApiClientRequest
    {
        /// <summary>
        /// Gọi API /api/v1/VoiceKeys/usage/tts để ghi nhận ký tự sử dụng
        /// Server trả response bọc trong ApiResponse wrapper { error, message, code, data }
        /// </summary>
        /// <returns>TtsUsageResponse (data bên trong wrapper) hoặc null nếu failed</returns>
        public async Task<TtsUsageResponse> LogTtsUsageAsync(string appCode, string productSlug, string text, string source)
        {
            string requestUrl = _baseUrl + "/api/v1/VoiceKeys/usage/tts";
            var requestBody = new TtsUsageRequest
            {
                AppCode = appCode,
                ProductSlug = productSlug,
                Text = text,
                Source = source
            };
            var apiResponse = await SendPostRequestAsync<ApiResponse<TtsUsageResponse>>(_apiKey, requestUrl, requestBody);
            return apiResponse?.Data;
        }
    }
}
