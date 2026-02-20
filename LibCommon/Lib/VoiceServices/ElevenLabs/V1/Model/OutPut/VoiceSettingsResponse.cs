using Newtonsoft.Json;

namespace Lib.VoiceServices.ElevenLabs.V1.Model
{
    public sealed class VoiceSettings
    {
        [JsonConstructor]
        public VoiceSettings(
            float stability = .75f,
            float similarityBoost = .75f,
            bool speakerBoost = true,
            float style = 0.45f,
            // [V2-UPDATE] Thêm parameter speed - tốc độ nói (default 1.0)
            float speed = 1f)
        {
            Stability = stability;
            SimilarityBoost = similarityBoost;
            Style = style;
            SpeakerBoost = speakerBoost;
            // [V2-UPDATE] Gán giá trị speed
            Speed = speed;
        }

        [JsonProperty("stability")]
        public float Stability { get; set; }

        [JsonProperty("similarity_boost")]
        public float SimilarityBoost { get; set; }

        [JsonProperty("style")]
        public float Style { get; set; }

        [JsonProperty("use_speaker_boost")]
        public bool SpeakerBoost { get; set; }

        // [V2-UPDATE] Thêm Speed property - tốc độ nói (0.25 đến 4.0, default 1.0)
        [JsonProperty("speed")]
        public float Speed { get; set; }
    }
}
