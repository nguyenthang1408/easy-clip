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
            float style = 0.45f)
        {
            Stability = stability;
            SimilarityBoost = similarityBoost;
            Style = style;
            SpeakerBoost = speakerBoost;
        }

        [JsonProperty("stability")]
        public float Stability { get; set; }

        [JsonProperty("similarity_boost")]
        public float SimilarityBoost { get; set; }

        [JsonProperty("style")]
        public float Style { get; set; }

        [JsonProperty("use_speaker_boost")]
        public bool SpeakerBoost { get; set; }
    }
}
