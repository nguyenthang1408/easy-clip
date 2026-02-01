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
        /// FFmpeg preset cho merge (CPU)
        /// </summary>
        public const string FFMPEG_PRESET_CPU = "superfast";

        /// <summary>
        /// FFmpeg preset cho merge (GPU)
        /// </summary>
        public const string FFMPEG_PRESET_GPU = "fast";

        /// <summary>
        /// Video codec (CPU - libx264)
        /// </summary>
        public const string VIDEO_CODEC_CPU = "libx264";

        /// <summary>
        /// Video codec (GPU - NVIDIA h264_nvenc)
        /// </summary>
        public const string VIDEO_CODEC_GPU = "h264_nvenc";

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
