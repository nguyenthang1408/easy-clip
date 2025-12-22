using Newtonsoft.Json;
using System;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Response model cho API GetVersion/ReviewMovie
    /// </summary>
    public class GetVersionResponse
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

        /// <summary>
        /// Tính số ngày còn lại của gói
        /// </summary>
        public int GetDaysRemaining()
        {
            if (!ExpiryDate.HasValue)
                return 0;

            var timeSpan = ExpiryDate.Value - DateTime.Now;
            return timeSpan.Days > 0 ? timeSpan.Days : 0;
        }
    }
}
