using ReviewMovie.Localization;

namespace ReviewMovie.Base
{
    /// <summary>
    /// String constants cho GPU Detection
    /// Hỗ trợ đa ngôn ngữ thông qua LanguageManager
    /// </summary>
    public static class GpuDetectionMessages
    {
        #region Error Messages - Thông báo lỗi chi tiết (localized)

        public static string ERROR_FFMPEG_NOT_FOUND => LanguageManager.Get(LangKeys.Gpu_FfmpegNotFound);
        public static string ERROR_ENCODER_NOT_FOUND => LanguageManager.Get(LangKeys.Gpu_EncoderNotFound);
        public static string ERROR_DRIVER_NOT_SUPPORT => LanguageManager.Get(LangKeys.Gpu_DriverNotSupport);
        public static string ERROR_API_VERSION_MISMATCH => LanguageManager.Get(LangKeys.Gpu_ApiVersionMismatch);
        public static string ERROR_DRIVER_TOO_OLD => LanguageManager.Get(LangKeys.Gpu_DriverTooOld);
        public static string ERROR_ENCODER_INIT_FAILED => LanguageManager.Get(LangKeys.Gpu_EncoderInitFailed);
        public static string ERROR_ENCODER_OPEN_FAILED => LanguageManager.Get(LangKeys.Gpu_EncoderOpenFailed);
        public static string ERROR_ENCODING_FAILED => LanguageManager.Get(LangKeys.Gpu_EncodingFailed);
        public static string ERROR_NO_DEVICE_FOUND => LanguageManager.Get(LangKeys.Gpu_NoDeviceFound);
        public static string ERROR_CANNOT_LOAD_NVCUDA => LanguageManager.Get(LangKeys.Gpu_CannotLoadNvcuda);
        public static string ERROR_CANNOT_LOAD_NVENC_API => LanguageManager.Get(LangKeys.Gpu_CannotLoadNvencApi);
        public static string ERROR_FUNCTION_NOT_IMPLEMENTED => LanguageManager.Get(LangKeys.Gpu_FunctionNotImpl);
        public static string ERROR_INVALID_ARGUMENT => LanguageManager.Get(LangKeys.Gpu_InvalidArgument);
        public static string ERROR_OUTPUT_STREAM_INIT => LanguageManager.Get(LangKeys.Gpu_OutputStreamInit);

        #endregion

        #region FFmpeg Error Patterns - Pattern lỗi FFmpeg (không đổi, dùng để detect từ output FFmpeg)

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

        #region User-Friendly Messages - Thông báo cho user (localized)

        public static string MSG_GPU_NOT_AVAILABLE => LanguageManager.Get(LangKeys.Gpu_NotAvailable);
        public static string MSG_ERROR_PREFIX => LanguageManager.Get(LangKeys.Gpu_ErrorPrefix);
        public static string MSG_SWITCH_TO_CPU => LanguageManager.Get(LangKeys.Gpu_SwitchToCpu);

        public static string GUIDE_FFMPEG_NOT_FOUND => LanguageManager.Get(LangKeys.Gpu_GuideFfmpeg);
        public static string GUIDE_DRIVER_TOO_OLD => LanguageManager.Get(LangKeys.Gpu_GuideDriverOld);
        public static string GUIDE_NO_DEVICE_FOUND => LanguageManager.Get(LangKeys.Gpu_GuideNoDevice);
        public static string GUIDE_GENERAL => LanguageManager.Get(LangKeys.Gpu_GuideGeneral);

        #endregion

        #region Auto-Detection Messages - Thông báo auto-detect (localized)

        public static string DETECT_GPU_AVAILABLE_TITLE => LanguageManager.Get(LangKeys.Gpu_DetectTitle);
        public static string DETECT_GPU_AVAILABLE_MESSAGE => LanguageManager.Get(LangKeys.Gpu_DetectMessage);
        public static string VALIDATE_GPU_FAILED_TITLE => LanguageManager.Get(LangKeys.Gpu_ValidateFailedTitle);

        #endregion

        #region Test Messages - Thông báo test (localized)

        // Keep prefix pattern for format methods
        public static string TEST_ENCODING_FAILED_PREFIX => LanguageManager.Get(LangKeys.Gpu_TestEncodingFailed);
        public static string TEST_GPU_ERROR_PREFIX => LanguageManager.Get(LangKeys.Gpu_TestGpuError);
        public static string UNKNOWN_ERROR_PREFIX => LanguageManager.Get(LangKeys.Gpu_UnknownError);

        #endregion

        #region Helper Methods - Phương thức trợ giúp

        /// <summary>
        /// Tạo message lỗi với exit code
        /// </summary>
        public static string GetEncodingFailedMessage(int exitCode)
        {
            return LanguageManager.GetFormat(LangKeys.Gpu_TestEncodingFailed, exitCode);
        }

        /// <summary>
        /// Tạo message lỗi test GPU
        /// </summary>
        public static string GetTestGpuErrorMessage(string errorDetail)
        {
            return LanguageManager.GetFormat(LangKeys.Gpu_TestGpuError, errorDetail);
        }

        /// <summary>
        /// Tạo message lỗi không xác định
        /// </summary>
        public static string GetUnknownErrorMessage(string errorDetail)
        {
            return LanguageManager.GetFormat(LangKeys.Gpu_UnknownError, errorDetail);
        }

        #endregion
    }
}
