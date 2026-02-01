namespace ReviewMovie.Base
{
    /// <summary>
    /// Kết quả kiểm tra GPU
    /// </summary>
    public class GpuDetectionResult
    {
        /// <summary>
        /// GPU có khả dụng không
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Thông báo lỗi chi tiết (nếu có)
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Loại lỗi
        /// </summary>
        public GpuErrorType ErrorType { get; set; }

        public GpuDetectionResult()
        {
            IsAvailable = false;
            ErrorMessage = string.Empty;
            ErrorType = GpuErrorType.None;
        }
    }

    /// <summary>
    /// Các loại lỗi GPU
    /// </summary>
    public enum GpuErrorType
    {
        None,
        FfmpegNotFound,
        EncoderNotFound,
        DriverTooOld,
        ApiVersionMismatch,
        EncoderInitFailed,
        NoDeviceFound,
        LibraryLoadFailed,
        UnknownError
    }
}
