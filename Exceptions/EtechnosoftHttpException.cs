using System;
using System.Net.Http;

namespace Etechnosoft.Common.Exceptions
{
    [Serializable]
    public class EtechnosoftHttpException : Exception
    {
        private readonly HttpResponseMessage _response;

        public EtechnosoftHttpException(HttpResponseMessage response):base($"{response.RequestMessage.RequestUri}.{response.StatusCode.ToString()}")
        {
            _response = response;
        }
    }
}