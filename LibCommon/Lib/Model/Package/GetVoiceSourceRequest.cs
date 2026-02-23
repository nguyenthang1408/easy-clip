using Newtonsoft.Json;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Request model cho API GetVoiceSourceEnum
    /// </summary>
    public class GetVoiceSourceRequest
    {
        [JsonProperty("appCode")]
        public string AppCode { get; set; }

        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }
    }
}
