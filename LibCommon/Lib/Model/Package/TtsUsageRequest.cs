using Newtonsoft.Json;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Request model cho API /api/v1/VoiceKeys/usage/tts
    /// Ghi nhận số ký tự đã sử dụng khi convert audio
    /// </summary>
    public class TtsUsageRequest
    {
        [JsonProperty("appCode")]
        public string AppCode { get; set; }

        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
