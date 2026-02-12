// [V2-UPDATE] HTTP client mới cho V2 - fix bug duplicate header của ApiClientRequest V1
// V1 ApiClientRequest dùng DefaultRequestHeaders.Add() mỗi lần gọi → header bị trùng → lỗi 400
// V2 dùng HttpRequestMessage per-request → header sạch mỗi lần gọi
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs
{
    /// <summary>
    /// [V2-UPDATE] HTTP client cho V2 - dùng per-request headers thay vì DefaultRequestHeaders
    /// Tham khảo: ElevenLabs-DotNet-20260211/ElevenLabs-DotNet/Common/ElevenLabsBaseEndPoint.cs
    /// </summary>
    public class ApiClientRequestV2
    {
        // [V2-UPDATE] Dùng static HttpClient (best practice) - tái sử dụng connection pool
        // Timeout tránh treo app khi mất mạng
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = NetworkConfig.Timeout
        };

        /// <summary>
        /// [V2-UPDATE] GET request - dùng HttpRequestMessage để set header per-request (không bị trùng)
        /// </summary>
        public async Task<HttpResponseMessage> GetAsync(string url, string apiKey, CancellationToken cancellationToken = default)
        {
            try
            {
                // [V2-UPDATE] Dùng HttpRequestMessage thay vì DefaultRequestHeaders
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("xi-api-key", apiKey);

                HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// [V2-UPDATE] POST request - dùng HttpRequestMessage để set header per-request
        /// </summary>
        public async Task<HttpResponseMessage> PostAsync(string url, object jsonData, string apiKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("xi-api-key", apiKey);
                request.Content = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
