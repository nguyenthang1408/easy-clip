using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs.V1.Services
{
    public class GetAudioInHistory
    {
        public string ApiKey { get; }
        public string ElevenlabsDownloadAudioAdress { get; }

        ApiClientRequest apiClientRequest = new ApiClientRequest();

        public GetAudioInHistory(string apikey)
        {
            ApiKey = apikey;
            ElevenlabsDownloadAudioAdress = $"{URLInfo.Https}{URLInfo.ElevenLabsDomain}{URLInfo.DefaultApiVersion}{URLInfo.History}";
        }
        public async Task<bool> DownloadAudioAsync(string historyItemId, string saveFilePath, CancellationToken cancellationToken = default)
        {
            var urlGetAudio = $"{ElevenlabsDownloadAudioAdress}{historyItemId}{URLInfo.HistoryAudio}";

            HttpResponseMessage response = await apiClientRequest.GetAsync(urlGetAudio, ApiKey, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var audioContent = await response.Content.ReadAsByteArrayAsync();

                using (var fileStream = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    await fileStream.WriteAsync(audioContent, 0, audioContent.Length);
                }
                return true;
            }
            else
            {
                //var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
        }
    }
}
