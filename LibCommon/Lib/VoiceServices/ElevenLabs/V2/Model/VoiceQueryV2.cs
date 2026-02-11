// [V2-UPDATE] Query parameters cho API /v2/voices - hỗ trợ search, filter, pagination
using System.Collections.Generic;

namespace Lib.VoiceServices.ElevenLabs.V2.Model
{
    /// <summary>
    /// [V2-UPDATE] Query parameters cho GET /v2/voices
    /// </summary>
    public class VoiceQueryV2
    {
        /// <summary>
        /// Token phân trang, lấy từ NextPageToken của response trước
        /// </summary>
        public string NextPageToken { get; set; }

        /// <summary>
        /// Số lượng voice mỗi trang (max 100, default 10)
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Tìm kiếm theo name, description, labels, category
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Sắp xếp theo: "created_at_unix" hoặc "name"
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Hướng sắp xếp: "asc" hoặc "desc"
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// Lọc theo loại voice: "personal", "community", "default", "workspace", "non-default"
        /// </summary>
        public string VoiceType { get; set; }

        /// <summary>
        /// Lọc theo category: "premade", "cloned", "generated", "professional"
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// [V2-UPDATE] Build query string từ các property có giá trị
        /// </summary>
        public string ToQueryString()
        {
            var parameters = new List<string>();

            if (!string.IsNullOrEmpty(NextPageToken))
                parameters.Add($"next_page_token={NextPageToken}");
            if (PageSize.HasValue)
                parameters.Add($"page_size={PageSize.Value}");
            if (!string.IsNullOrEmpty(Search))
                parameters.Add($"search={System.Uri.EscapeDataString(Search)}");
            if (!string.IsNullOrEmpty(Sort))
                parameters.Add($"sort={Sort}");
            if (!string.IsNullOrEmpty(SortDirection))
                parameters.Add($"sort_direction={SortDirection}");
            if (!string.IsNullOrEmpty(VoiceType))
                parameters.Add($"voice_type={VoiceType}");
            if (!string.IsNullOrEmpty(Category))
                parameters.Add($"category={Category}");

            return parameters.Count > 0 ? "?" + string.Join("&", parameters) : string.Empty;
        }
    }
}
