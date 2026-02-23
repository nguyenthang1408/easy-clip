// [V2-UPDATE] Model mới cho API /v2/voices - hỗ trợ pagination
// Tái sử dụng Voice, VoiceSettings từ V1 Model
using Lib.VoiceServices.ElevenLabs.V1.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lib.VoiceServices.ElevenLabs.V2.Model
{
    /// <summary>
    /// [V2-UPDATE] Response từ GET /v2/voices - có thêm pagination fields
    /// </summary>
    public class VoiceListV2
    {
        [JsonProperty("voices")]
        public IReadOnlyList<Voice> Voices { get; set; }

        // [V2-UPDATE] Các field pagination mới từ API v2
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }
    }
}
