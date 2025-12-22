using Newtonsoft.Json;
using System;

namespace Common.Model
{
    public class VersionResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("packageId")]
        public string PackageId { get; set; }

        [JsonProperty("packageType")]
        public string PackageType { get; set; }

        [JsonProperty("expiryDate")]
        public DateTime? ExpiryDate { get; set; }
    }
}
