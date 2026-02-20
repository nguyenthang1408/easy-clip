using System;
using System.Collections.Generic;

namespace LibCommon.Lib
{
    /// <summary>
    /// Helper chuyển đổi mã code từ server sang thông báo cho người dùng.
    /// Quy ước code: 2xxx = success, 1xxx = business error, 4xxx = client error, 5xxx = server error.
    /// Hỗ trợ đa ngôn ngữ thông qua callback delegate (tránh circular reference).
    /// </summary>
    public static class VersionMessageHelper
    {
        // Mã code từ server
        public const int CodeSuccess = 2000;
        public const int CodeSuccessNoSubscription = 2001;
        public const int CodeInvalidApiKey = 1001;
        public const int CodeUserInactive = 1002;
        public const int CodeProductNotFound = 1003;
        public const int CodeDeviceNotFound = 1004;
        public const int CodeInvalidRequest = 4000;
        public const int CodeInternalError = 5000;

        /// <summary>
        /// Delegate nhận langKey và trả về text đã dịch.
        /// Được set từ app layer (ReviewMovie) khi khởi tạo.
        /// </summary>
        public static Func<string, string> GetLocalizedText { get; set; }

        // Mapping code -> LangKey
        private static readonly Dictionary<int, string> _codeLangKeyMap = new Dictionary<int, string>
        {
            { CodeSuccess,                "Version_Success" },
            { CodeSuccessNoSubscription,  "Version_NoSubscription" },
            { CodeInvalidApiKey,          "Version_InvalidApiKey" },
            { CodeUserInactive,           "Version_UserInactive" },
            { CodeProductNotFound,        "Version_ProductNotFound" },
            { CodeDeviceNotFound,         "Version_DeviceNotFound" },
            { CodeInvalidRequest,         "Version_InvalidRequest" },
            { CodeInternalError,          "Version_InternalError" },
        };

        // Vietnamese messages (fallback)
        private static readonly Dictionary<int, string> _vietnameseMessages = new Dictionary<int, string>
        {
            { CodeSuccess,                "Đăng nhập thành công!" },
            { CodeSuccessNoSubscription,  "Tài khoản chưa kích hoạt gói dịch vụ hoặc gói đã hết hạn." },
            { CodeInvalidApiKey,          "API Key không hợp lệ hoặc không tồn tại. Vui lòng kiểm tra lại." },
            { CodeUserInactive,           "Tài khoản không hoạt động hoặc API đã bị tắt. Vui lòng liên hệ quản trị viên." },
            { CodeProductNotFound,        "Sản phẩm không tồn tại hoặc không hoạt động. Vui lòng kiểm tra lại." },
            { CodeDeviceNotFound,         "Thiết bị không tồn tại cho sản phẩm này. Vui lòng đăng ký thiết bị hoặc kiểm tra lại mã ứng dụng." },
            { CodeInvalidRequest,         "Yêu cầu không hợp lệ. Vui lòng kiểm tra lại." },
            { CodeInternalError,          "Lỗi hệ thống, vui lòng thử lại sau." },
        };

        /// <summary>
        /// Lấy thông báo dựa trên ngôn ngữ hiện tại.
        /// Ưu tiên dùng GetLocalizedText delegate nếu đã được set.
        /// </summary>
        public static string GetMessage(int code)
        {
            try
            {
                if (GetLocalizedText != null && _codeLangKeyMap.TryGetValue(code, out string langKey))
                {
                    var msg = GetLocalizedText(langKey);
                    if (msg != null && !msg.StartsWith("[")) return msg;
                }
            }
            catch
            {
                // Fallback to Vietnamese if delegate fails
            }

            return GetVietnameseMessage(code);
        }

        /// <summary>
        /// Lấy thông báo tiếng Việt dựa trên mã code từ server (backward compatibility).
        /// </summary>
        public static string GetVietnameseMessage(int code)
        {
            if (_vietnameseMessages.TryGetValue(code, out string message))
                return message;

            return "Đã xảy ra lỗi không xác định. Vui lòng thử lại sau.";
        }
    }
}
