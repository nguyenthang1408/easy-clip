using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Response model cho API /api/v1/VoiceKeys/current (data bên trong ApiResponse wrapper)
    /// </summary>
    public class GetVoiceSourceResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("unlimit")]
        public bool Unlimit { get; set; }

        [JsonProperty("voiceType")]
        public string VoiceType { get; set; }

        [JsonProperty("providerName")]
        public string ProviderName { get; set; }

        [JsonProperty("packageId")]
        public string PackageId { get; set; }

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

        [JsonProperty("assignedAt")]
        public DateTime? AssignedAt { get; set; }

        [JsonProperty("activeUsers")]
        public int ActiveUsers { get; set; }

        [JsonProperty("maxActiveUsers")]
        public int MaxActiveUsers { get; set; }

        [JsonProperty("allowedLanguages")]
        public List<AllowedLanguage> AllowedLanguages { get; set; }

        [JsonProperty("allowedTotalVoices")]
        public int AllowedTotalVoices { get; set; }

        [JsonProperty("characterUsed")]
        public long CharacterUsed { get; set; }

        [JsonProperty("characterLimit")]
        public long? CharacterLimit { get; set; }

        [JsonProperty("dailyCharacterUsed")]
        public long DailyCharacterUsed { get; set; }

        [JsonProperty("dailyCharacterLimit")]
        public int? DailyCharacterLimit { get; set; }

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
