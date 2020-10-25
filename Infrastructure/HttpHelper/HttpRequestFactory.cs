using System.Net.Http;
using System.Threading.Tasks;

namespace Etechnosoft.Common.Infrastructure.HttpHelper
{
    public static class HttpRequestFactory
    {
        public static async Task<HttpResponseMessage> Get(string requestUri)
        {
            var builder = HttpRequestBuilder.CreateWithUri(requestUri)
                .AddMethod(HttpMethod.Get);
            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value = null)
        {
            var builder =  HttpRequestBuilder.CreateWithUri(requestUri)
                .AddMethod(HttpMethod.Post)
                .AddContent(new JsonContent(value??new object()));
            return await builder.SendAsync();
        }
     
        public static async Task<HttpResponseMessage> Delete(string requestUri)
        {
            var builder =  HttpRequestBuilder.CreateWithUri(requestUri)
                .AddMethod(HttpMethod.Delete);
            return await builder.SendAsync();
        }
    }
}