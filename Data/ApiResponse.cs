using System.Collections.Generic;

namespace Etechnosoft.Common.Data
{
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }

    public class ApiResponse
    {
        public Dictionary<string, string[]> ValidationErrors { get; set; }
        public ServiceResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get;  set; }

    }
}