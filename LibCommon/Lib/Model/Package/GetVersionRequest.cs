using Newtonsoft.Json;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Request model cho API GetVersion/ReviewMovie
    /// </summary>
    public class GetVersionRequest
    {
        [JsonProperty("appCode")]
        public string AppCode { get; set; }

        [JsonProperty("productSlug")]
        public string ProductSlug { get; set; }
    }
}
