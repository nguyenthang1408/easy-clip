using LibCommon.Lib.Model.Package;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibCommon.Lib.Services
{
    /// <summary>
    /// Service để gọi các API liên quan đến Package
    /// </summary>
    public class PackageService
    {
        private const string BASE_URL = "https://t2psoft.com";
        private const string API_VERSION = "1.0";

        private readonly HttpClient _httpClient;

        public PackageService(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            _httpClient.DefaultRequestHeaders.Add("X-Version", API_VERSION);
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
        }

        /// <summary>
        /// Gọi API GetVersion/ReviewMovie để lấy thông tin gói của user
        /// </summary>
        /// <param name="appCode">Mã ứng dụng</param>
        /// <param name="appName">Tên ứng dụng</param>
        /// <returns>GetVersionResponse hoặc null nếu failed</returns>
        public async Task<GetVersionResponse> GetVersionAsync(string appCode, string appName)
        {
            try
            {
                var request = new GetVersionRequest
                {
                    AppCode = appCode,
                    AppName = appName
                };

                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                string requestUrl = BASE_URL + "/api/v1/GetVersion/ReviewMovie";
                var response = await _httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetVersionResponse>(responseContent);

                    if (result != null && result.IsSuccess)
                    {
                        return result;
                    }
                }

                // Nếu failed, trả về null
                return null;
            }
            catch (Exception ex)
            {
                // Log error nếu cần
                Console.WriteLine($"Error calling GetVersion API: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gọi API GetVoiceSourceEnum để lấy thông tin voice source
        /// </summary>
        /// <returns>GetVoiceSourceResponse hoặc null nếu failed</returns>
        public async Task<GetVoiceSourceResponse> GetVoiceSourceEnumAsync()
        {
            try
            {
                var request = new GetVoiceSourceRequest();
                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                string requestUrl = BASE_URL + "/GetVoiceSourceEnum";
                var response = await _httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetVoiceSourceResponse>(responseContent);

                    if (result != null && result.IsSuccess)
                    {
                        return result;
                    }
                }

                // Nếu failed, trả về null
                return null;
            }
            catch (Exception ex)
            {
                // Log error nếu cần
                Console.WriteLine($"Error calling GetVoiceSourceEnum API: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Dispose HttpClient khi không dùng nữa
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
