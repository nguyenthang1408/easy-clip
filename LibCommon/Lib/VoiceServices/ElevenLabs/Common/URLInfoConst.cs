
namespace Lib.VoiceServices.ElevenLabs
{
    internal class URLInfo
    {
        public const string Https = "https://";
        public const string DefaultApiVersion = "/v1";
        // [V2-UPDATE] Thêm API version V2 cho voices endpoint mới
        public const string ApiVersionV2 = "/v2";
        public const string ElevenLabsDomain = "api.elevenlabs.io";

        public const string Voice = "/voices";
        public const string VoiceSetting = "/settings";
        public const string VoiceSettingEdit = "/settings/edit";

        public const string TextToSpeech = "/text-to-speech/";

        public const string History = "/history/";
        public const string HistoryAudio = "/audio";
    }
}
