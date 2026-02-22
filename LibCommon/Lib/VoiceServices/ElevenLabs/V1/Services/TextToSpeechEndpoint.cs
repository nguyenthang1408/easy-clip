using Lib.VoiceServices.ElevenLabs.V1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs.V1.Services
{
    public class TextToSpeechEndpoint
    {
        public string ApiKey { get; }
        public string ElevenlabsText2speechAdress { get; }

        ApiClientRequest apiClientRequest = new ApiClientRequest();

        public TextToSpeechEndpoint(string apikey)
        {
            ApiKey = apikey;
            ElevenlabsText2speechAdress = $"{URLInfo.Https}{URLInfo.ElevenLabsDomain}{URLInfo.DefaultApiVersion}{URLInfo.TextToSpeech}";
        }
        public async Task<TextToSpeechResponse> SendTextToSpeechRequestAsync(string voiceId, TextToSpeechRequest request, OutputFormat outputFormat = OutputFormat.MP3_44100_32, bool enableLogging = true, CancellationToken cancellationToken = default)
        {
            var urlTextToSpeech = $"{ElevenlabsText2speechAdress}{voiceId}?enable_logging={enableLogging}&output_format={outputFormat.ToString().ToLower()}";
            var postResponse = await apiClientRequest.PostAsync(urlTextToSpeech, request, ApiKey, cancellationToken);

            if (postResponse.IsSuccessStatusCode)
            {
                var audioContent = await postResponse.Content.ReadAsByteArrayAsync();

                // Tạo đối tượng đầu ra để trả về
                var ttsResponse = new TextToSpeechResponse
                {
                    AudioContent = audioContent,
                    RequestId = postResponse.Headers.GetValues("request-id").FirstOrDefault(),
                    HistoryItemId = postResponse.Headers.GetValues("history-item-id").FirstOrDefault(),
                    CharacterCost = int.Parse(postResponse.Headers.GetValues("character-cost").FirstOrDefault()),
                    TtsLatencyMs = int.Parse(postResponse.Headers.GetValues("tts-latency-ms").FirstOrDefault()),
                    ContentType = postResponse.Content.Headers.ContentType.ToString()
                };

                return ttsResponse;
            }
            else
            {
                return null;

                //var errorContent = await postResponse.Content.ReadAsStringAsync();
                //throw new Exception($"Request failed with status {postResponse.StatusCode}: {errorContent}");
            }
        }
    }
}
