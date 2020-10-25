using System.Net.Http;
using Etechnosoft.Common.Data;
using Etechnosoft.Common.Exceptions;
using Newtonsoft.Json;

namespace Etechnosoft.Common.Infrastructure.HttpHelper
{
    public static class HttpResponseExtensions
    {
        public static T ClientContent<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new EtechnosoftHttpException(response);
            var result = JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content.ReadAsStringAsync().Result);
            if (result.ResponseCode == ServiceResponseCode.Ok) return result.Data;
            throw new EtechnosoftException(result);
        }
        public static void ClientContent(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)throw new EtechnosoftHttpException(response);
            var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);
            if (result.ResponseCode != ServiceResponseCode.Ok)
                throw new EtechnosoftException(result);
        }

    }
}