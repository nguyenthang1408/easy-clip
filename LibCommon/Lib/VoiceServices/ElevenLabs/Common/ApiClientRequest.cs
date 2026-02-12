using Lib.VoiceServices.ElevenLabs.V1.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs
{
    public class ApiClientRequest
    {
        private readonly HttpClient _httpClient;

        public ApiClientRequest()
        {
            _httpClient = new HttpClient
            {
                Timeout = NetworkConfig.Timeout
            };
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string apiKey)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("xi-api-key", apiKey);
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                return response;
            }
            catch
            {
                return null;
            }
        }
        public async Task<HttpResponseMessage> PostAsync(string url, object jsonData, string apiKey)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("xi-api-key", apiKey);

                HttpContent content = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
