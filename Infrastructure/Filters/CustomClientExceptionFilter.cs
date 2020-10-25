using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Etechnosoft.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Etechnosoft.Common.Infrastructure.Filters
{
    public class CustomClientExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomClientExceptionFilter> _logger;

        public CustomClientExceptionFilter(ILogger<CustomClientExceptionFilter> logger)
        {
            _logger = logger;
        }
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var ex = context.Exception;
            string message;
            object validationErrors = null;
            if (ex is EtechnosoftHttpException httpEx)
            {
                message = "Error occured. Please try again.";
                _logger.LogError(ex.Message, httpEx);
            }
            else if (ex is EtechnosoftException exception)
            {
                message = exception.Message;
                validationErrors = exception.ValidationErrors;
            }
            else
            {
                message = ex.ToString();
                _logger.LogError(ex.Message, ex);
            }
            context.Result = new JsonResult(new
            {
                message,
                validationErrors
            });
            return Task.CompletedTask;
        }
    }
}