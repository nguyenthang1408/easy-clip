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

        // [V2-UPDATE] Thêm model_id - chọn model TTS (eleven_flash_v2, eleven_multilingual_v2, ...)
        // Nếu null sẽ dùng model mặc định của ElevenLabs
        [JsonProperty("model_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModelId { get; set; }

        // [V2-UPDATE] Thêm language_code - mã ngôn ngữ ISO 639-1 (vd: "vi", "en", "ja")
        // Chỉ hỗ trợ với model eleven_turbo_v2_5
        [JsonProperty("language_code", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        // [V2-UPDATE] Thêm seed - cho output deterministic (0-4294967295)
        [JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
        public int? Seed { get; set; }

        // [V2-UPDATE] Thêm previous_text/next_text - cho continuity giữa các đoạn
        [JsonProperty("previous_text", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousText { get; set; }

        [JsonProperty("next_text", NullValueHandling = NullValueHandling.Ignore)]
        public string NextText { get; set; }

        // [V2-UPDATE] Thêm previous_request_ids - stitching với request trước (max 3)
        [JsonProperty("previous_request_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] PreviousRequestIds { get; set; }

        // [V2-UPDATE] Thêm next_request_ids - stitching với request sau (max 3)
        [JsonProperty("next_request_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] NextRequestIds { get; set; }
    }
}
