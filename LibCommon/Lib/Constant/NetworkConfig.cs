using System;

namespace Lib
{
    /// <summary>
    /// Cấu hình timeout cho các network call (HTTP, gRPC, download)
    /// Tránh treo app khi mất kết nối mạng
    /// </summary>
    public static class NetworkConfig
    {
        /// <summary>
        /// Timeout (giây) cho các network call
        /// </summary>
        public const int TimeoutSeconds = 7;

        /// <summary>
        /// Timeout (milliseconds) cho HttpWebRequest
        /// </summary>
        public const int TimeoutMs = TimeoutSeconds * 1000;

        /// <summary>
        /// TimeSpan timeout - dùng cho HttpClient.Timeout, CancellationTokenSource, gRPC CallSettings
        /// </summary>
        public static readonly TimeSpan Timeout = TimeSpan.FromSeconds(TimeoutSeconds);
    }
}
