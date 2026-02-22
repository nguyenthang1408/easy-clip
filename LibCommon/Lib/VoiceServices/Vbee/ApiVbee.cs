using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Lib
{
    public class Iobject
    {
        public bool ResultCode;
        public string uri;
        public string savepath;
        public string filename;
    }

    public class TextToSpeechModelInput
    {
        public string linksite { get; set; }
        public string token { get; set; }
        public string appId { get; set; }
        public string voidcode { get; set; }
        public string speedrate { get; set; }
        public string inputText { get; set; }
    }

    public class TextToSpeechModelOutput
    {
        public TextToSpeechModelItem result { get; set; }
        public int status { get; set; }
    }

    public class TextToSpeechModelItem
    {
        public string app_id { get; set; }
        public string audio_type { get; set; }
        public int bitrate { get; set; }
        public int characters { get; set; }
        public string request_id { get; set; }
        public string speed_rate { get; set; }
        public string status { get; set; }
        public string voice_code { get; set; }
    }

    public class GetaudioModelInput
    {
        public string linksite { get; set; }
        public string token { get; set; }
        public string requestID { get; set; }
    }

    public class GetaudioModelOutput
    {
        public GetaudioModelItem result { get; set; }
        public int status { get; set; }
    }

    public class GetaudioModelItem
    {
        public string app_id { get; set; }
        public string audio_link { get; set; }
        public string audio_type { get; set; }
        public int bitrate { get; set; }
        public int characters { get; set; }
        public string request_id { get; set; }
        public string speed_rate { get; set; }
        public string status { get; set; }
        public string voice_code { get; set; }
    }

    public partial class ApiVbee
    {
        public ApiVbee() { }

        // Note Used => Test OK => delete
        public TextToSpeechModelOutput PostTextToSpeech(TextToSpeechModelInput input)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(input.linksite);
                request.Timeout = NetworkConfig.TimeoutMs;
                request.ReadWriteTimeout = NetworkConfig.TimeoutMs;
                var postData = @"{" + "\n" +
                                @"    ""app_id"": """ + input.appId + @"""," + "\n" +
                                @"    ""response_type"": ""indirect""," + "\n" +
                                @"    ""callback_url"": ""https://mydomain/callback""," + "\n" +
                                @"    ""input_text"": """ + input.inputText + @"""," + "\n" +
                                @"    ""voice_code"": """ + input.voidcode + @"""," + "\n" +
                                @"    ""audio_type"":""mp3""," + "\n" +
                                @"    ""bitrate"": 128," + "\n" +
                                @"    ""speed_rate"": """ + input.speedrate + @"""" + "\n" +
                                @"}";

                var data = Encoding.UTF8.GetBytes(postData);
                request.Headers.Add("Authorization", $"Bearer {input.token}");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = (new StreamReader(response.GetResponseStream())).ReadToEnd();


                var output = JsonConvert.DeserializeObject<TextToSpeechModelOutput>(responseString);
                return output;
            }
            catch
            {
                return null;
            }
        }

        public string ConvertText2Speech(string iAppID, string iToken, string ivoidcode, string iSpeedrate, string inputtext)
        {
            var input = new TextToSpeechModelInput
            {
                linksite = "https://vbee.vn/api/v1/tts",
                token = iToken,
                appId = iAppID,
                voidcode = ivoidcode,
                speedrate = iSpeedrate,
                inputText = inputtext
            };
            var ouput = PostTextToSpeech(input);
            return ouput?.result?.request_id ?? string.Empty;
        }
        // End check

        public async Task<TextToSpeechModelOutput> PostTextToSpeechAsync(TextToSpeechModelInput input, CancellationToken cancellationToken = default)
        {
            try
            {
                var postData = @"{" + "\n" +
                                @"    ""app_id"": """ + input.appId + @"""," + "\n" +
                                @"    ""response_type"": ""indirect""," + "\n" +
                                @"    ""callback_url"": ""https://mydomain/callback""," + "\n" +
                                @"    ""input_text"": """ + input.inputText + @"""," + "\n" +
                                @"    ""voice_code"": """ + input.voidcode + @"""," + "\n" +
                                @"    ""audio_type"":""mp3""," + "\n" +
                                @"    ""bitrate"": 128," + "\n" +
                                @"    ""speed_rate"": """ + input.speedrate + @"""" + "\n" +
                                @"}";

                using (var client = new HttpClient { Timeout = NetworkConfig.Timeout })
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", input.token);

                    var content = new StringContent(postData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(input.linksite, content, cancellationToken);
                    var responseString = await response.Content.ReadAsStringAsync();

                    var output = JsonConvert.DeserializeObject<TextToSpeechModelOutput>(responseString);
                    return output;
                }
            }
            catch (OperationCanceledException) { throw; }
            catch
            {
                return null;
            }
        }

        public async Task<string> ConvertText2SpeechAsync(string iAppID, string iToken, string ivoidcode, string iSpeedrate, string inputtext, CancellationToken cancellationToken = default)
        {
            var input = new TextToSpeechModelInput
            {
                linksite = "https://vbee.vn/api/v1/tts",
                token = iToken,
                appId = iAppID,
                voidcode = ivoidcode,
                speedrate = iSpeedrate,
                inputText = inputtext
            };

            var output = await PostTextToSpeechAsync(input, cancellationToken);
            return output?.result?.request_id ?? string.Empty;
        }

        public async Task<GetaudioModelOutput> GetLinkaudioAsync(GetaudioModelInput input)
        {
            if (input == null 
                || string.IsNullOrWhiteSpace(input.linksite) 
                || string.IsNullOrWhiteSpace(input.token) 
                || string.IsNullOrWhiteSpace(input.requestID))
                return null;

            try
            {
                using (var client = new HttpClient { Timeout = NetworkConfig.Timeout })
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", input.token);

                    string requestUrl = $"{input.linksite}/{input.requestID}";
                    var response = await client.GetAsync(requestUrl);

                    if (!response.IsSuccessStatusCode)
                        return null;

                    string responseString = await response.Content.ReadAsStringAsync();
                    var output = JsonConvert.DeserializeObject<GetaudioModelOutput>(responseString);

                    return output;
                }
            }
            catch
            {
                return null;
            }
        }



        public GetaudioModelOutput GetLinkaudio(GetaudioModelInput input)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(input.linksite + "/" + input.requestID);
                request.Timeout = NetworkConfig.TimeoutMs;
                request.ReadWriteTimeout = NetworkConfig.TimeoutMs;
                request.Headers.Add("Authorization", $"Bearer {input.token}");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var output = JsonConvert.DeserializeObject<GetaudioModelOutput>(responseString);
                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
