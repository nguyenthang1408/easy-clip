using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Response model cho API GetVoiceSourceEnum
    /// </summary>
    public class GetVoiceSourceResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("unlimit")]
        public bool Unlimit { get; set; }

        [JsonProperty("voiceType")]
        public string VoiceType { get; set; }

        [JsonProperty("voiceKey")]
        public string VoiceKey { get; set; }

        [JsonProperty("packageId")]
        public string PackageId { get; set; }

        [JsonProperty("allowedLanguages")]
        public List<AllowedLanguage> AllowedLanguages { get; set; }

        [JsonProperty("allowedTotalVoices")]
        public int AllowedTotalVoices { get; set; }

        public GetVoiceSourceResponse()
        {
            AllowedLanguages = new List<AllowedLanguage>();
        }
    }

    /// <summary>
    /// Model cho ngôn ngữ được phép
    /// </summary>
    public class AllowedLanguage
    {
        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }
}
