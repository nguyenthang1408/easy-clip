using Newtonsoft.Json;
using System;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Response model cho API GetVersion/EasyClip
    /// </summary>
    public class GetVersionResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

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
        /// Trả về số dương nếu còn hạn, 0 nếu hết hạn hôm nay, số âm nếu đã quá hạn
        /// </summary>
        public int GetDaysRemaining()
        {
            if (!ExpiryDate.HasValue)
                return 0;

            var timeSpan = ExpiryDate.Value.Date - DateTime.Now.Date;
            return timeSpan.Days;
        }

        /// <summary>
        /// Kiểm tra dữ liệu response có đầy đủ không
        /// Trả về true nếu tất cả các trường bắt buộc đều có giá trị
        /// </summary>
        public bool IsDataValid()
        {
            return !string.IsNullOrEmpty(Version)
                && !string.IsNullOrEmpty(Email)
                && !string.IsNullOrEmpty(PackageId)
                && !string.IsNullOrEmpty(PackageType)
                && ExpiryDate.HasValue;
        }
    }
}
