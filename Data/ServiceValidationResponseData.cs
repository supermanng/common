using System.Collections.Generic;

namespace Etechnosoft.Common.Data
{
    public class ServiceResponseValidationData : ServiceResponseData
    {

        public ServiceResponseValidationData(ServiceResponseCode responseCode, string message, IDictionary<string, string[]> validationErrors)
            : base(responseCode, message)
        {
            ValidationErrors = validationErrors;
        }

        public IDictionary<string, string[]> ValidationErrors { get; }
    }
}