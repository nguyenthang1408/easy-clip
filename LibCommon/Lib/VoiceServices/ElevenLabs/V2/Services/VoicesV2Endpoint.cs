// [V2-UPDATE] VoicesV2Endpoint - Gọi API /v2/voices thay cho /v1/voices
// Tái sử dụng: ApiClientRequest, Voice model, VoiceSettings từ V1
// Khác V1: dùng /v2, hỗ trợ pagination, search, filter
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Lib.VoiceServices.ElevenLabs.V2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs.V2.Services
{
    /// <summary>
    /// [V2-UPDATE] Endpoint voices API v2 - hỗ trợ pagination, search, filter
    /// Tái sử dụng ApiClientRequest và Voice/VoiceSettings model từ V1
    /// </summary>
    public class VoicesV2Endpoint
    {
        public string ApiKey { get; }

        // [V2-UPDATE] Đổi sang /v2 thay vì /v1
        public string ElevenlabsV2Address { get; }

        // [V2-UPDATE] Tái sử dụng ApiClientRequest từ V1
        private readonly ApiClientRequest _apiClientRequest = new ApiClientRequest();

        public VoicesV2Endpoint(string apiKey)
        {
            ApiKey = apiKey;
            // [V2-UPDATE] URL mới: https://api.elevenlabs.io/v2/voices
            ElevenlabsV2Address = $"{URLInfo.Https}{URLInfo.ElevenLabsDomain}{URLInfo.ApiVersionV2}{URLInfo.Voice}";
        }

        /// <summary>
        /// [V2-UPDATE] Lấy tất cả voices qua API v2 - tự động phân trang để lấy hết
        /// Tương thích ngược: trả về IReadOnlyList&lt;Voice&gt; giống V1
        /// </summary>
        public Task<IReadOnlyList<Voice>> GetAllVoicesAsync(CancellationToken cancellationToken = default)
            => GetAllVoicesAsync(true, cancellationToken);

        /// <summary>
        /// [V2-UPDATE] Lấy tất cả voices qua API v2 - tự động phân trang
        /// downloadSettings: nếu true sẽ gọi thêm API lấy settings cho mỗi voice (tái sử dụng logic V1)
        /// </summary>
        public async Task<IReadOnlyList<Voice>> GetAllVoicesAsync(bool downloadSettings, CancellationToken cancellationToken = default)
        {
            var allVoices = new List<Voice>();
            string nextPageToken = null;

            // [V2-UPDATE] Loop phân trang - lấy hết tất cả voices
            do
            {
                var query = new VoiceQueryV2
                {
                    PageSize = 100, // [V2-UPDATE] Max page size cho v2
                    NextPageToken = nextPageToken
                };

                string url = $"{ElevenlabsV2Address}{query.ToQueryString()}";
                HttpResponseMessage response = await _apiClientRequest.GetAsync(url, ApiKey);

                if (response == null || !response.IsSuccessStatusCode)
                {
                    // [V2-UPDATE] Nếu V2 thất bại, trả null để caller xử lý
                    return null;
                }

                string content = await response.Content.ReadAsStringAsync();
                var voiceList = JsonConvert.DeserializeObject<VoiceListV2>(content);

                if (voiceList?.Voices != null)
                {
                    allVoices.AddRange(voiceList.Voices);
                }

                // [V2-UPDATE] Kiểm tra còn trang tiếp theo không
                nextPageToken = voiceList?.HasMore == true ? voiceList.NextPageToken : null;

            } while (!string.IsNullOrEmpty(nextPageToken));

            // [V2-UPDATE] Download settings cho mỗi voice - tái sử dụng logic giống V1
            if (downloadSettings && allVoices.Count > 0)
            {
                var voiceSettingsTasks = new List<Task>();

                foreach (var voice in allVoices)
                {
                    voiceSettingsTasks.Add(Task.Run(async () =>
                    {
                        voice.Settings = await GetVoiceSettingsAsync(voice.VoiceId).ConfigureAwait(false);
                    }, cancellationToken));
                }

                await Task.WhenAll(voiceSettingsTasks).ConfigureAwait(false);
            }

            return allVoices;
        }

        /// <summary>
        /// [V2-UPDATE] Lấy voices với query tùy chỉnh (search, filter, pagination)
        /// Trả về VoiceListV2 có thêm HasMore, TotalCount, NextPageToken
        /// </summary>
        public async Task<VoiceListV2> GetVoicesAsync(VoiceQueryV2 query = null, CancellationToken cancellationToken = default)
        {
            query = query ?? new VoiceQueryV2();
            string url = $"{ElevenlabsV2Address}{query.ToQueryString()}";
            HttpResponseMessage response = await _apiClientRequest.GetAsync(url, ApiKey);

            if (response == null || !response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VoiceListV2>(content);
        }

        /// <summary>
        /// [V2-UPDATE] Tái sử dụng: lấy VoiceSettings - vẫn dùng /v1/voices/{id}/settings (V2 không có endpoint này)
        /// </summary>
        private async Task<VoiceSettings> GetVoiceSettingsAsync(string voiceId)
        {
            if (string.IsNullOrWhiteSpace(voiceId))
                return null;

            // [V2-UPDATE] Voice settings vẫn dùng V1 endpoint
            string url = $"{URLInfo.Https}{URLInfo.ElevenLabsDomain}{URLInfo.DefaultApiVersion}{URLInfo.Voice}/{voiceId}{URLInfo.VoiceSetting}";
            HttpResponseMessage response = await _apiClientRequest.GetAsync(url, ApiKey);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VoiceSettings>(content);
        }
    }
}
