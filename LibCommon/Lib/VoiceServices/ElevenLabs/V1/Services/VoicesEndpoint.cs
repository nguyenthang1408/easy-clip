using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lib.VoiceServices.ElevenLabs;
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Newtonsoft.Json;

namespace Lib.VoiceServices.ElevenLabs.V1.Services
{
    public class VoicesEndpoint
    {
        public VoicesEndpoint( string apikey) 
        {
            ApiKey = apikey;
            ElevenlabsAdress = $"{URLInfo.Https}{URLInfo.ElevenLabsDomain}{URLInfo.DefaultApiVersion}";
        }
        public string ApiKey { get; }
        public string ElevenlabsAdress { get; }

        ApiClientRequest apiClientRequest = new ApiClientRequest();

        public Task<IReadOnlyList<Voice>> GetAllVoicesAsync(CancellationToken cancellationToken = default)
        => GetAllVoicesAsync(true, cancellationToken);

        public async Task<IReadOnlyList<Voice>> GetAllVoicesAsync(bool downloadSettings, CancellationToken cancellationToken = default)
        {
            string urlGetVoices = $"{ElevenlabsAdress}{URLInfo.Voice}";
            HttpResponseMessage response = await apiClientRequest.GetAsync(urlGetVoices, ApiKey);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var voices = JsonConvert.DeserializeObject<VoiceList>(content).Voices;
                var voiceSettingsTasks = new List<Task>();

                foreach (var voice in voices)
                {
                    voiceSettingsTasks.Add(Task.Run(LocalGetVoiceSettingsAsync, cancellationToken));

                    async Task LocalGetVoiceSettingsAsync()
                    {
                        voice.Settings = await GetVoiceSettingsAsync(voice.VoiceId).ConfigureAwait(false);
                    }
                }

                await Task.WhenAll(voiceSettingsTasks).ConfigureAwait(false);
                return voices?.ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task<VoiceSettings> GetVoiceSettingsAsync(string voiceId)
        {
            if (string.IsNullOrWhiteSpace(voiceId))
            {
                throw new ArgumentNullException(nameof(voiceId));
            }

            var apiRequest = new ApiClientRequest();
            string urlGetVoices = $"{ElevenlabsAdress}{URLInfo.Voice}/{voiceId}{URLInfo.VoiceSetting}";

            HttpResponseMessage response = await apiRequest.GetAsync(urlGetVoices, ApiKey);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var voiceSetting = JsonConvert.DeserializeObject<VoiceSettings>(content);

                return voiceSetting;
            }
            else
            {
                return null;
            }
        }
    }
}
