using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Etechnosoft.Common.Infrastructure.HttpHelper
{
    public class HttpRequestBuilder
    {
        private HttpMethod _method = null;
        private string _requestUri = "";
        private HttpContent _content = null;
        private string _bearerToken = "";
        private string _acceptHeader = "application/json";
        private TimeSpan _timeout = new TimeSpan(0, 1, 0);

        private HttpRequestBuilder()
        {
        }

        public HttpRequestBuilder AddMethod(HttpMethod method)
        {
            this._method = method;
            return this;
        }

        public static HttpRequestBuilder CreateWithUri(string requestUri)
        {
            var builder = new HttpRequestBuilder()
                .AddMethod(HttpMethod.Post);
            builder._requestUri = requestUri;
            return builder;
        }

        public HttpRequestBuilder AddContent(HttpContent content)
        {
            this._content = content;
            return this;
        }

        public HttpRequestBuilder AddJsonContent(object content)
        {
            this._content = new JsonContent(content);
            return this;
        }
        public HttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this._bearerToken = bearerToken;
            return this;
        }

        public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this._acceptHeader = acceptHeader;
            return this;
        }

        public HttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this._timeout = timeout;
            return this;
        }
        public async Task<HttpResponseMessage> SendAsync()
        {
         
            // Setup request  
            var request = new HttpRequestMessage
            {
                Method = this._method,
                RequestUri = new Uri(this._requestUri)
            };

            if (this._content != null)
                request.Content = this._content;

            if (!string.IsNullOrEmpty(this._bearerToken))
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", this._bearerToken);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this._acceptHeader))
                request.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(this._acceptHeader));

            // Setup client  
            var client = new System.Net.Http.HttpClient {Timeout = this._timeout};

            return await client.SendAsync(request);
        }
    }
}