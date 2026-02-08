namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Enum định nghĩa các loại gói dịch vụ
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// Gói Trial - Giới hạn voice source, ngôn ngữ và giọng đọc
        /// </summary>
        Trial,

        /// <summary>
        /// Gói Basic - Không giới hạn ngôn ngữ và giọng đọc, chỉ hiển thị T2Psoft.com
        /// </summary>
        Basic,

        /// <summary>
        /// Gói Premium - Không giới hạn, hiển thị full voice sources
        /// </summary>
        Premium
    }

    /// <summary>
    /// Helper class để xử lý PackageType
    /// </summary>
    public static class PackageTypeHelper
    {
        // Package ID constants
        /// PKG_TRIAL_000
        /// PKG_BASIC_001/003/006/012
        /// PKG_PREMIUM_001/003/006/012
        public const string PKG_TRIAL = "PKG_TRIAL_000";
        public const string PKG_BASIC_PREFIX = "PKG_BASIC_";
        public const string PKG_PREMIUM_PREFIX = "PKG_PREMIUM_";

        /// <summary>
        /// Chuyển đổi packageId từ server thành PackageType enum
        /// </summary>
        public static PackageType GetPackageType(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
                return PackageType.Trial;

            if (packageId.Contains("PREMIUM"))
                return PackageType.Premium;

            if (packageId.Contains("BASIC"))
                return PackageType.Basic;

            return PackageType.Trial;
        }

        /// <summary>
        /// Parse số tháng từ packageId (3 ký tự cuối)
        /// VD: PKG_BASIC_003 -> 3, PKG_PREMIUM_012 -> 12, PKG_TRIAL_000 -> 0
        /// </summary>
        public static int GetMonthsFromPackageId(string packageId)
        {
            if (string.IsNullOrEmpty(packageId) || packageId.Length < 3)
                return 0;

            string suffix = packageId.Substring(packageId.Length - 3);
            if (int.TryParse(suffix, out int months))
                return months;

            return 0;
        }

        /// <summary>
        /// Lấy tên hiển thị gói kèm số tháng
        /// VD: "Basic - 3 tháng", "Premium - 12 tháng", "Trial"
        /// </summary>
        public static string GetPackageDisplayName(string packageType, string packageId)
        {
            int months = GetMonthsFromPackageId(packageId);
            if (months > 0)
                return $"{packageType} - {months} tháng";

            return packageType ?? "Trial";
        }

        /// <summary>
        /// Kiểm tra xem package có phải là unlimited không
        /// </summary>
        public static bool IsUnlimited(PackageType packageType)
        {
            return packageType == PackageType.Basic || packageType == PackageType.Premium;
        }
    }
}
