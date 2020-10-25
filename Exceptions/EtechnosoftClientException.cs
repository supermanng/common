using System;
using Etechnosoft.Common.Data;

namespace Etechnosoft.Common.Exceptions
{
    [Serializable]
    public class EtechnosoftClientException : Exception
    {
        public ApiResponse Response { get; }

        public EtechnosoftClientException(string message) : base(message)
        {

        }
        public EtechnosoftClientException(ApiResponse response) : base(response.ResponseMessage)
        {
            Response = response;
        }
    }
}