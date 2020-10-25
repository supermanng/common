using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Etechnosoft.Common.Data;
using Etechnosoft.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Etechnosoft.Common.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomServiceExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomClientExceptionFilter> _logger;

        public CustomServiceExceptionFilter(ILogger<CustomClientExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            object response;
            if (context.Exception is EtechnosoftHttpException e)
            {
                response = new ServiceResponseData(ServiceResponseCode.BadRequest,
                    "Error occured. Please try again.");
                _logger.LogCritical(e.Message);
            }
            else if (context.Exception is EtechnosoftException ex)
            {
                response = ex.ErrorCode == ServiceResponseCode.ValidationError
                    ? new ServiceResponseValidationData(ex.ErrorCode, ex.Message, ex.ValidationErrors)
                    : new ServiceResponseData(ex.ErrorCode, ex.Message);
            }
            else
            {
                response = new ServiceResponseData(ServiceResponseCode.InternalServerError,
                    $"{context.Exception.ToString()}");
                _logger.LogError(context.Exception.Message, context.Exception);
            }

            context.Result = new JsonResult(response);
        }
    }
}