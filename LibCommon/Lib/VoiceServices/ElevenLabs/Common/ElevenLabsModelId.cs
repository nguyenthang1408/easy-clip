// [V2-UPDATE] Constants cho các ElevenLabs Model IDs
// Dùng khi truyền model_id vào TextToSpeechRequest

namespace Lib.VoiceServices.ElevenLabs
{
    /// <summary>
    /// [V2-UPDATE] Danh sách model IDs của ElevenLabs
    /// Tham khảo: ElevenLabs-DotNet-20260211/ElevenLabs-DotNet/Models/Model.cs
    /// </summary>
    public static class ElevenLabsModelId
    {
        /// <summary>
        /// Model mặc định - Flash V2 (nhanh, chất lượng tốt)
        /// </summary>
        public const string FlashV2 = "eleven_flash_v2";

        /// <summary>
        /// Flash V2.5 - phiên bản cải tiến của Flash V2
        /// </summary>
        public const string FlashV2_5 = "eleven_flash_v2_5";

        /// <summary>
        /// English Turbo V2 - tối ưu cho tiếng Anh
        /// </summary>
        public const string EnglishTurboV2 = "eleven_turbo_v2";

        /// <summary>
        /// Turbo V2.5 - hỗ trợ language_code enforcement
        /// </summary>
        public const string TurboV2_5 = "eleven_turbo_v2_5";

        /// <summary>
        /// Multilingual V1 - đa ngôn ngữ phiên bản 1
        /// </summary>
        public const string MultiLingualV1 = "eleven_multilingual_v1";

        /// <summary>
        /// Multilingual V2 - đa ngôn ngữ phiên bản 2 (chất lượng cao)
        /// </summary>
        public const string MultiLingualV2 = "eleven_multilingual_v2";

        /// <summary>
        /// English V1 - phiên bản cũ cho tiếng Anh
        /// </summary>
        public const string EnglishV1 = "eleven_monolingual_v1";
    }
}
