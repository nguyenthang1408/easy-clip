namespace ReviewMovie.Base
{
    /// <summary>
    /// Configuration constants cho video merge
    /// </summary>
    public static class VideoMergeConfig
    {
        /// <summary>
        /// Số luồng validate song song (default: 20)
        /// </summary>
        public const int MAX_PARALLEL_VALIDATION_THREADS = 20;

        /// <summary>
        /// FFmpeg preset cho merge
        /// </summary>
        public const string FFMPEG_PRESET = "superfast";

        /// <summary>
        /// Video codec
        /// </summary>
        public const string VIDEO_CODEC = "libx264";

        /// <summary>
        /// Pixel format
        /// </summary>
        public const string PIXEL_FORMAT = "yuv420p";

        /// <summary>
        /// Format datetime cho output folder/file
        /// </summary>
        public const string DATETIME_FORMAT = "yyyyMMdd_HHmmss";

        /// <summary>
        /// Tên prefix cho output folder và file
        /// </summary>
        public const string OUTPUT_PREFIX = "output";

        /// <summary>
        /// Update progress mỗi N videos
        /// </summary>
        public const int PROGRESS_UPDATE_INTERVAL = 10;
    }
}
