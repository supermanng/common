using Etechnosoft.Common.Extensions;

namespace Etechnosoft.Common.Data
{
    public class ServiceResponseData<T> : ServiceResponseData
    {
        public T Data { get; set; }

    }

    public class ServiceResponseData
    {
        public ServiceResponseCode ResponseCode { get; }

        protected ServiceResponseData()
            : this(ServiceResponseCode.Ok, ServiceResponseCode.Ok.GetMesage())
        {
        }

        public static ServiceResponseData SuccessfulResponse()
        {
            return new ServiceResponseData();
        }
        public string ResponseMessage { get; }

        public ServiceResponseData(ServiceResponseCode responseCode, string message)
        {
            ResponseCode = responseCode;
            ResponseMessage = message;
        }

    }

}