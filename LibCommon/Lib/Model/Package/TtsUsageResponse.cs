using Newtonsoft.Json;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Response model cho API /api/v1/VoiceKeys/usage/tts (data bên trong ApiResponse wrapper)
    /// </summary>
    public class TtsUsageResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseMsgCode")]
        public int ResponseMsgCode { get; set; }

        [JsonProperty("isWarning")]
        public bool IsWarning { get; set; }

        [JsonProperty("voiceType")]
        public string VoiceType { get; set; }

        [JsonProperty("providerName")]
        public string ProviderName { get; set; }

        [JsonProperty("keyName")]
        public string KeyName { get; set; }

        [JsonProperty("keyId")]
        public long KeyId { get; set; }

        [JsonProperty("voiceKey")]
        public string VoiceKey { get; set; }

        [JsonProperty("keyTs")]
        public long KeyTs { get; set; }

        [JsonProperty("keyVersion")]
        public string KeyVersion { get; set; }

        [JsonProperty("characterUsed")]
        public long CharacterUsed { get; set; }

        [JsonProperty("characterLimit")]
        public long? CharacterLimit { get; set; }

        [JsonProperty("dailyCharacterUsed")]
        public long DailyCharacterUsed { get; set; }

        [JsonProperty("dailyCharacterLimit")]
        public int? DailyCharacterLimit { get; set; }

        [JsonProperty("characterCount")]
        public int CharacterCount { get; set; }
    }
}
