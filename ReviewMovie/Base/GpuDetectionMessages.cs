namespace ReviewMovie.Base
{
    /// <summary>
    /// String constants cho GPU Detection
    /// Tách riêng để hỗ trợ đa ngôn ngữ trong tương lai
    /// </summary>
    public static class GpuDetectionMessages
    {
        #region Error Messages - Thông báo lỗi chi tiết

        public const string ERROR_FFMPEG_NOT_FOUND = "Không tìm thấy FFmpeg.exe";
        public const string ERROR_ENCODER_NOT_FOUND = "h264_nvenc không có trong danh sách encoders";
        public const string ERROR_DRIVER_NOT_SUPPORT = "Driver NVIDIA không hỗ trợ phiên bản NVENC API yêu cầu";
        public const string ERROR_API_VERSION_MISMATCH = "Phiên bản NVENC API không tương thích";
        public const string ERROR_DRIVER_TOO_OLD = "Driver NVIDIA quá cũ, cần cập nhật driver";
        public const string ERROR_ENCODER_INIT_FAILED = "Không thể khởi tạo encoder NVENC";
        public const string ERROR_ENCODER_OPEN_FAILED = "Không thể mở encoder NVENC";
        public const string ERROR_ENCODING_FAILED = "GPU encoding thất bại";
        public const string ERROR_NO_DEVICE_FOUND = "Không tìm thấy GPU hỗ trợ NVENC";
        public const string ERROR_CANNOT_LOAD_NVCUDA = "Không load được nvcuda.dll";
        public const string ERROR_CANNOT_LOAD_NVENC_API = "Không load được nvEncodeAPI";
        public const string ERROR_FUNCTION_NOT_IMPLEMENTED = "Chức năng không được hỗ trợ";
        public const string ERROR_INVALID_ARGUMENT = "Tham số không hợp lệ";
        public const string ERROR_OUTPUT_STREAM_INIT = "Lỗi khởi tạo output stream";

        #endregion

        #region FFmpeg Error Patterns - Pattern lỗi FFmpeg

        public const string PATTERN_DRIVER_NOT_SUPPORT = "Driver does not support";
        public const string PATTERN_NVENC_API_VERSION = "nvenc API version";
        public const string PATTERN_MIN_REQUIRED_DRIVER = "minimum required Nvidia driver";
        public const string PATTERN_ERROR_OPENING_ENCODER = "Error while opening encoder";
        public const string PATTERN_COULD_NOT_OPEN_ENCODER = "Could not open encoder";
        public const string PATTERN_CONVERSION_FAILED = "Conversion failed";
        public const string PATTERN_NO_NVENC_DEVICES = "No NVENC capable devices found";
        public const string PATTERN_CANNOT_LOAD_NVCUDA = "Cannot load nvcuda.dll";
        public const string PATTERN_CANNOT_LOAD_NVENC_API = "Cannot load nvEncodeAPI";
        public const string PATTERN_FUNCTION_NOT_IMPLEMENTED = "Function not implemented";
        public const string PATTERN_INVALID_ARGUMENT = "Invalid argument";
        public const string PATTERN_ERROR_INIT_OUTPUT = "Error initializing output stream";

        #endregion

        #region User-Friendly Messages - Thông báo cho user

        public const string MSG_GPU_NOT_AVAILABLE = "GPU NVIDIA không khả dụng!";
        public const string MSG_ERROR_PREFIX = "Lỗi: ";
        public const string MSG_SWITCH_TO_CPU = "\n\nHệ thống sẽ chuyển về sử dụng CPU.";

        // Hướng dẫn theo loại lỗi
        public const string GUIDE_FFMPEG_NOT_FOUND =
            "FFmpeg chưa được cài đặt hoặc không tìm thấy.\n" +
            "Vui lòng tải và cài đặt FFmpeg.";

        public const string GUIDE_DRIVER_TOO_OLD =
            "Vui lòng cập nhật driver NVIDIA lên phiên bản mới nhất.";

        public const string GUIDE_NO_DEVICE_FOUND =
            "Không tìm thấy GPU NVIDIA hỗ trợ NVENC.\n" +
            "Cần card đồ họa NVIDIA GTX 600 series trở lên.";

        public const string GUIDE_GENERAL =
            "Vui lòng kiểm tra:\n" +
            "- Card đồ họa NVIDIA có hỗ trợ NVENC (GTX 600 series trở lên)\n" +
            "- Driver NVIDIA đã được cài đặt và cập nhật\n" +
            "- FFmpeg được build với hỗ trợ NVENC";

        #endregion

        #region Auto-Detection Messages - Thông báo auto-detect

        public const string DETECT_GPU_AVAILABLE_TITLE = "Đề xuất sử dụng GPU";
        public const string DETECT_GPU_AVAILABLE_MESSAGE =
            "Phát hiện GPU NVIDIA hỗ trợ h264_nvenc!\n\n" +
            "GPU rendering nhanh hơn CPU khoảng 5-10 lần.\n\n" +
            "Bạn có muốn sử dụng GPU để render không?";

        public const string VALIDATE_GPU_FAILED_TITLE = "GPU không hoạt động";

        #endregion

        #region Test Messages - Thông báo test

        public const string TEST_ENCODING_FAILED_PREFIX = "GPU encoding test thất bại (exit code: ";
        public const string TEST_GPU_ERROR_PREFIX = "Lỗi test GPU: ";
        public const string UNKNOWN_ERROR_PREFIX = "Lỗi không xác định: ";

        #endregion

        #region Helper Methods - Phương thức trợ giúp

        /// <summary>
        /// Tạo message lỗi với exit code
        /// </summary>
        public static string GetEncodingFailedMessage(int exitCode)
        {
            return $"{TEST_ENCODING_FAILED_PREFIX}{exitCode})";
        }

        /// <summary>
        /// Tạo message lỗi test GPU
        /// </summary>
        public static string GetTestGpuErrorMessage(string errorDetail)
        {
            return $"{TEST_GPU_ERROR_PREFIX}{errorDetail}";
        }

        /// <summary>
        /// Tạo message lỗi không xác định
        /// </summary>
        public static string GetUnknownErrorMessage(string errorDetail)
        {
            return $"{UNKNOWN_ERROR_PREFIX}{errorDetail}";
        }

        #endregion
    }
}
