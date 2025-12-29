using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.VoiceServices.GoogleTTS
{
    public static class GoogleTTSVoiceCode
    {
        // Từ điển tĩnh chứa mã ngôn ngữ và tên hiển thị (chỉ tạo 1 lần duy nhất)
        // Google TTS API chỉ trả về language code (en-US, vi-VN), không có tên tiếng Việt
        // Nên cần dictionary này để map code sang tên hiển thị
        private static readonly Dictionary<string, string> LanguageMap = new Dictionary<string, string>
        {
            { "af-ZA", "Tiếng Afrikaans (Nam Phi)" },
            { "am-ET", "Tiếng Amharic (Ethiopia)" },
            { "ar-XA", "Tiếng Ả Rập" },
            { "bg-BG", "Tiếng Bulgaria" },
            { "bn-IN", "Tiếng Bengal (Ấn Độ)" },
            { "ca-ES", "Tiếng Catalan (Tây Ban Nha)" },
            { "cmn-CN", "Tiếng Quan Thoại (Trung Quốc)" },
            { "cmn-TW", "Tiếng Quan Thoại (Đài Loan)" },
            { "cs-CZ", "Tiếng Séc (Cộng hòa Séc)" },
            { "da-DK", "Tiếng Đan Mạch" },
            { "de-DE", "Tiếng Đức" },
            { "el-GR", "Tiếng Hy Lạp" },
            { "en-AU", "Tiếng Anh (Úc)" },
            { "en-GB", "Tiếng Anh (Anh)" },
            { "en-IN", "Tiếng Anh (Ấn Độ)" },
            { "en-US", "Tiếng Anh (Mỹ)" },
            { "es-ES", "Tiếng Tây Ban Nha (Tây Ban Nha)" },
            { "es-US", "Tiếng Tây Ban Nha (Mỹ)" },
            { "et-EE", "Tiếng Estonia" },
            { "eu-ES", "Tiếng Basque (Tây Ban Nha)" },
            { "fi-FI", "Tiếng Phần Lan" },
            { "fil-PH", "Tiếng Filipino (Philippines)" },
            { "fr-CA", "Tiếng Pháp (Canada)" },
            { "fr-FR", "Tiếng Pháp (Pháp)" },
            { "gl-ES", "Tiếng Galicia (Tây Ban Nha)" },
            { "gu-IN", "Tiếng Gujarati (Ấn Độ)" },
            { "he-IL", "Tiếng Hebrew (Israel)" },
            { "hi-IN", "Tiếng Hindi (Ấn Độ)" },
            { "hu-HU", "Tiếng Hungary" },
            { "id-ID", "Tiếng Indonesia" },
            { "is-IS", "Tiếng Iceland" },
            { "it-IT", "Tiếng Ý" },
            { "ja-JP", "Tiếng Nhật" },
            { "kn-IN", "Tiếng Kannada (Ấn Độ)" },
            { "ko-KR", "Tiếng Hàn Quốc" },
            { "lt-LT", "Tiếng Lithuania" },
            { "lv-LV", "Tiếng Latvia" },
            { "ml-IN", "Tiếng Malayalam (Ấn Độ)" },
            { "mr-IN", "Tiếng Marathi (Ấn Độ)" },
            { "ms-MY", "Tiếng Malaysia" },
            { "nb-NO", "Tiếng Na Uy (Bokmål)" },
            { "nl-BE", "Tiếng Hà Lan (Bỉ)" },
            { "nl-NL", "Tiếng Hà Lan (Hà Lan)" },
            { "pa-IN", "Tiếng Punjabi (Ấn Độ)" },
            { "pl-PL", "Tiếng Ba Lan" },
            { "pt-BR", "Tiếng Bồ Đào Nha (Brazil)" },
            { "pt-PT", "Tiếng Bồ Đào Nha (Bồ Đào Nha)" },
            { "ro-RO", "Tiếng Romania" },
            { "ru-RU", "Tiếng Nga" },
            { "sk-SK", "Tiếng Slovakia" },
            { "sr-RS", "Tiếng Serbia" },
            { "sv-SE", "Tiếng Thụy Điển" },
            { "ta-IN", "Tiếng Tamil (Ấn Độ)" },
            { "te-IN", "Tiếng Telugu (Ấn Độ)" },
            { "th-TH", "Tiếng Thái Lan" },
            { "tr-TR", "Tiếng Thổ Nhĩ Kỳ" },
            { "uk-UA", "Tiếng Ukraina" },
            { "ur-IN", "Tiếng Urdu (Ấn Độ)" },
            { "vi-VN", "Tiếng Việt" },
            { "yue-HK", "Tiếng Quảng Đông (Hồng Kông)" }
        };

        public static string GetLanguageDisplayName(string languageCode)
        {
            // Kiểm tra và trả về tên hiển thị hoặc mã ngôn ngữ nếu không tìm thấy
            return LanguageMap.TryGetValue(languageCode, out var name) ? name : languageCode;
        }
    }
}
