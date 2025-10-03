using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lib.VoiceServices.ElevenLabs.V1.Model
{
    public class VoiceList
    {
        [JsonProperty("voices")]
        public IReadOnlyList<Voice> Voices { get; private set; }
    }
    public class Voice
    {
        [JsonProperty("voice_id")]
        public string VoiceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("samples")]
        public List<Sample> Samples { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("fine_tuning")]
        public FineTuning FineTuning { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("available_for_tiers")]
        public List<string> AvailableForTiers { get; set; }

        [JsonProperty("settings")]
        public VoiceSettings Settings { get; set; }

        [JsonProperty("sharing")]
        public object Sharing { get; set; }

        [JsonProperty("high_quality_base_model_ids")]
        public List<string> HighQualityBaseModelIds { get; set; }

        [JsonProperty("safety_control")]
        public object SafetyControl { get; set; }

        [JsonProperty("voice_verification")]
        public VoiceVerification VoiceVerification { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("permission_on_resource")]
        public object PermissionOnResource { get; set; }

        [JsonProperty("is_legacy")]
        public bool IsLegacy { get; set; }
    }

    public class Sample
    {
        [JsonProperty("sample_id")]
        public string SampleId { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("size_bytes")]
        public int SizeBytes { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class Recording
    {
        [JsonProperty("recording_id")]
        public string RecordingId { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("size_bytes")]
        public int SizeBytes { get; set; }

        [JsonProperty("upload_date_unix")]
        public int UploadDateUnix { get; set; }

        [JsonProperty("transcription")]
        public string Transcription { get; set; }
    }

    public class VerificationAttempt
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("date_unix")]
        public int DateUnix { get; set; }

        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("similarity")]
        public int Similarity { get; set; }

        [JsonProperty("levenshtein_distance")]
        public int LevenshteinDistance { get; set; }

        [JsonProperty("recording")]
        public Recording Recording { get; set; }
    }

    public class ManualVerification
    {
        [JsonProperty("extra_text")]
        public string ExtraText { get; set; }

        [JsonProperty("request_time_unix")]
        public int RequestTimeUnix { get; set; }

        [JsonProperty("files")]
        public List<Sample> Files { get; set; }
    }

    public class FineTuning
    {
        [JsonProperty("is_allowed_to_fine_tune")]
        public bool IsAllowedToFineTune { get; set; }

        [JsonProperty("state")]
        public object State { get; set; }

        [JsonProperty("verification_failures")]
        public List<string> VerificationFailures { get; set; }

        [JsonProperty("verification_attempts_count")]
        public int VerificationAttemptsCount { get; set; }

        [JsonProperty("manual_verification_requested")]
        public bool ManualVerificationRequested { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("progress")]
        public object Progress { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("dataset_duration_seconds")]
        public int? DatasetDurationSeconds { get; set; }

        [JsonProperty("verification_attempts")]
        public List<VerificationAttempt> VerificationAttempts { get; set; }

        [JsonProperty("slice_ids")]
        public List<string> SliceIds { get; set; }

        [JsonProperty("manual_verification")]
        public ManualVerification ManualVerification { get; set; }
    }

    public class Labels
    {
        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("use_case")]
        public string UseCase { get; set; }

        [JsonProperty("accent")]
        public string Accent { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class VoiceVerification
    {
        [JsonProperty("requires_verification")]
        public bool RequiresVerification { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("verification_failures")]
        public List<string> VerificationFailures { get; set; }

        [JsonProperty("verification_attempts_count")]
        public int VerificationAttemptsCount { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("verification_attempts")]
        public List<VerificationAttempt> VerificationAttempts { get; set; }
    }
}
