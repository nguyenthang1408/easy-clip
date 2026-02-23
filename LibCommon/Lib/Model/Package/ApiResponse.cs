using Newtonsoft.Json;

namespace LibCommon.Lib.Model.Package
{
    /// <summary>
    /// Generic wrapper cho response từ server có dạng { error, message, code, data }
    /// </summary>
    public class ApiResponse<T>
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
