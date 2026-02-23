using LibCommon.Lib.Model.Package;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public partial class ApiClientRequest
    {
        /// <summary>
        /// Gọi API /api/v1/VoiceKeys/current để lấy thông tin voice source (encrypted)
        /// Server trả response bọc trong ApiResponse wrapper { error, message, code, data }
        /// </summary>
        /// <returns>GetVoiceSourceResponse (data bên trong wrapper) hoặc null nếu failed</returns>
        public async Task<GetVoiceSourceResponse> GetVoiceSourceEnumAsync(string appCode, string appSlugID)
        {
            string requestUrl = _baseUrl + "/api/v1/VoiceKeys/current";
            var requestBody = new GetVoiceSourceRequest
            {
                AppCode = appCode,
                ProductSlug = appSlugID
            };
            var apiResponse = await SendPostRequestAsync<ApiResponse<GetVoiceSourceResponse>>(_apiKey, requestUrl, requestBody);
            return apiResponse?.Data;
        }
    }
}
