using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lib;
using System.Net.Http;
using Common.Model;

namespace Common.Services
{
    public class ApiClientRequest
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public ApiClientRequest(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public async Task<VersionResponse> ReviewMovieVersionAsync(string appCode, string appName)
        {
            //string requestUrl = _baseUrl + "/api/v1/GetVersion/ReviewMovie";
            string requestUrl = "http://localhost:3000/api/check";
            var requestBody = new
            {
                appCode = appCode,
                appName = appName
            };
            var response = await SendPostRequestAsync<VersionResponse>(_apiKey, requestUrl, requestBody);
            return response;
        }

        public async Task<VersionResponse> CutVideoVersionAsync()
        {
            string requestUrl = _baseUrl + "/api/v1/GetVersion/CutVideo";
            var response = await SendPostRequestAsync<VersionResponse>(_apiKey, requestUrl, null);
            return response;
        }

        //public async Task<CreateZoomResponse> CreateZoomEffectAsync(InputParamZoomV2Request zoomParams)
        //{
        //    string requestUrl = _baseUrl + "/api/v1/ZoomEffect/create";
        //    var response = await SendPostRequestAsync<CreateZoomResponse>(_apiKey, requestUrl, zoomParams);
        //    return response;
        //}

        public async Task<T> SendPostRequestAsync<T>(string  apikey, string requestUrl, object requestBody)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
                _httpClient.DefaultRequestHeaders.Add("X-Version", "1.0");
                _httpClient.DefaultRequestHeaders.Add("X-API-KEY", apikey);

                string jsonBody = requestBody != null ? JsonConvert.SerializeObject(requestBody) : string.Empty;
                HttpContent content = string.IsNullOrEmpty(jsonBody) ? null : new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    string errorResponse = response != null ? await response.Content.ReadAsStringAsync() : "No response from server";
                    throw new Exception(errorResponse);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


        public async Task<CreateZoomResponse> CreateZoomEffectAsync(InputParamZoomV2Request zoomParams)
        {
            try
            {
                var requestUrl = _baseUrl + "/api/v1/ZoomEffect/create";
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
                _httpClient.DefaultRequestHeaders.Add("X-Version", "1.0");
                _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);

                string jsonBody = JsonConvert.SerializeObject(new { zoomParams });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CreateZoomResponse>(responseString);
                }
                else
                {
                    string errorResponse = response != null ? await response.Content.ReadAsStringAsync() : "No response from server";
                    return new CreateZoomResponse
                    {
                        IsSuccess = false,
                        Message = errorResponse,
                    };
                }
            }
            catch (Exception ex)
            {
                return new CreateZoomResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public CreateZoomResponse CreateZoomEffect(InputParamZoomV2Request zoomParams)
        {
            try
            {
                var requestUrl = _baseUrl + "/api/v1/ZoomEffect/create";
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
                _httpClient.DefaultRequestHeaders.Add("X-Version", "1.0");
                _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);

                string jsonBody = JsonConvert.SerializeObject(new { zoomParams });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Dùng PostAsync và chuyển thành đồng bộ
                HttpResponseMessage response = _httpClient.PostAsync(requestUrl, content).GetAwaiter().GetResult();

                if (response != null && response.IsSuccessStatusCode)
                {
                    // Xử lý kết quả thành công
                    string responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<CreateZoomResponse>(responseData);
                }
                else
                {
                    // Xử lý lỗi server
                    return new CreateZoomResponse
                    {
                        IsSuccess = false,
                        Message = "Server Error!"
                    };
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return new CreateZoomResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}
