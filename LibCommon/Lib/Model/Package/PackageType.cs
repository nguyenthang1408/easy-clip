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
        public const string PKG_TRIAL = "PKG_TRIAL_001";
        public const string PKG_BASIC = "PKG_BASIC_001";
        public const string PKG_PREMIUM = "PKG_PREMIUM_001";

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
        /// Kiểm tra xem package có phải là unlimited không
        /// </summary>
        public static bool IsUnlimited(PackageType packageType)
        {
            return packageType == PackageType.Basic || packageType == PackageType.Premium;
        }
    }
}
