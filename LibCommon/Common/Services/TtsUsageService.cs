using LibCommon.Lib.Model.Package;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public partial class ApiClientRequest
    {
        /// <summary>
        /// Gọi API /api/v1/VoiceKeys/usage/tts để ghi nhận ký tự sử dụng.
        /// Không dùng SendPostRequestAsync vì server trả error 4xx với cùng JSON format
        /// { error, message, code, data } — cần deserialize cả khi HTTP status không phải 2xx.
        /// </summary>
        /// <returns>ApiResponse wrapper chứa error/message/data, hoặc null nếu request failed</returns>
        public async Task<ApiResponse<TtsUsageResponse>> LogTtsUsageAsync(string appCode, string productSlug, string text, string source)
        {
            string requestUrl = _baseUrl + "/api/v1/VoiceKeys/usage/tts";
            var requestBody = new TtsUsageRequest
            {
                AppCode = appCode,
                ProductSlug = productSlug,
                Text = text,
                Source = source
            };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
            _httpClient.DefaultRequestHeaders.Add("X-Version", "1.0");
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);

            string jsonBody = JsonConvert.SerializeObject(requestBody);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

            // Đọc body bất kể HTTP status code (2xx hay 4xx đều cùng JSON format)
            string responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse<TtsUsageResponse>>(responseString);
        }
    }
}
