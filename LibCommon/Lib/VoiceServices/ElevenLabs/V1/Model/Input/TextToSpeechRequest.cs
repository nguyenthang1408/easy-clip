using System;
using Newtonsoft.Json;

namespace Lib.VoiceServices.ElevenLabs.V1.Model
{
    public class TextToSpeechRequest
    {
        //public TextToSpeechRequest(string text, VoiceSettings voiceSettings)
        //{
        //    if (string.IsNullOrWhiteSpace(text))
        //    {
        //        throw new ArgumentNullException(nameof(text));
        //    }

        //    Text = text;
        //    VoiceSettings = voiceSettings ?? throw new ArgumentNullException(nameof(voiceSettings));
        //}

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("voice_settings")]
        public VoiceSettings VoiceSettings { get; set; }
    }
}
