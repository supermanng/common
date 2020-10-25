using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Etechnosoft.Common.Data;
using Etechnosoft.Common.Extensions;
using FluentValidation.Results;

namespace Etechnosoft.Common.Exceptions
{
    [Serializable]
    public class EtechnosoftException : Exception
    {
        public ServiceResponseCode ErrorCode { get; }
        public IDictionary<string, string[]> ValidationErrors { get; } 

        public EtechnosoftException(ApiResponse response) 
            : this(response.ResponseCode, response.ResponseMessage)
        {
            this.ValidationErrors = response.ValidationErrors;
        }

        public EtechnosoftException(string message) : base(message)
        {
            ErrorCode = ServiceResponseCode.BadRequest;
        }

        public EtechnosoftException(ServiceResponseCode errorCode):base(errorCode.GetMesage())
        {
            this.ErrorCode = errorCode;
        }
        public EtechnosoftException(ServiceResponseCode errorCode, string errormessage)
        :this(errormessage??errorCode.GetMesage())
        {
            ErrorCode = errorCode;
        }

       public EtechnosoftException(Dictionary<string, string[]> failures)
           : this(ServiceResponseCode.ValidationError, "One or more validation failures have occurred.")
        {
            this.ValidationErrors = failures;
        }
        public EtechnosoftException(List<ValidationFailure> failures)
            : this(ServiceResponseCode.ValidationError, "One or more validation failures have occurred.")
        {
            ValidationErrors = new Dictionary<string, string[]>();
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                ValidationErrors.Add(propertyName, propertyFailures);
            }
        }

    }
}