using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lib
{
    public partial class ApiFptAI
    {
        public ApiFptAI() { }

        private async Task<FptAIModelOutput> TextToSpeechRequestAsync(FptAIModelInput input)
        {
            try
            {
                string payload = input.textinput;
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(7) })
                {
                    client.DefaultRequestHeaders.Add("api-key", input.apikey);
                    client.DefaultRequestHeaders.Add("speed", input.speedrate);
                    client.DefaultRequestHeaders.Add("voice", input.voidcoce);

                    var response = await client.PostAsync("https://api.fpt.ai/hmi/tts/v5", new StringContent(payload));
                    string result = await response.Content.ReadAsStringAsync();

                    return new FptAIModelOutput
                    {
                        result = JsonConvert.DeserializeObject<FptAIResultItemm>(result),
                        status = true
                    };
                }
            }
            catch
            {
                return new FptAIModelOutput
                {
                    result = null,
                    status = false
                };
            }
        }


        public async Task<string> FptAIConvertText2SpeechAsync(string apiKey, string voiceCode, string speedRate, string inputText)
        {
            var input = new FptAIModelInput
            {
                textinput = inputText,
                apikey = apiKey,
                voidcoce = voiceCode,
                speedrate = speedRate
            };

            var output = await TextToSpeechRequestAsync(input);
            return output?.result?.async ?? string.Empty;
        }

    }

    public class FptAIVoicecodeModel
    {
        public string voicecode { get; set; }
        public string description { get; set; }
    }

    public class FptAIModelInput
    {
        public string textinput { get; set; }
        public string apikey { get; set; }
        public string speedrate { get; set; }
        public string voidcoce { get; set; }
    }

    public class FptAIModelOutput
    {
        public FptAIResultItemm result { get; set; }
        public bool status { get; set; }
    }

    public class FptAIResultItemm
    {
        public string async { get; set; }
        public int error { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
    }
}
