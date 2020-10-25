using System.Linq;
using System.Net;
using Etechnosoft.Common.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Etechnosoft.Common.Infrastructure.Filters
{
    public class SuccessResponseFormatterFilter : ActionFilterAttribute
    {
        private readonly string[] _excludedControllers = { "Upload" };
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"].ToString();
            if (_excludedControllers.Contains(controllerName)) return;
            if (context.Exception != null || context.HttpContext.Response.StatusCode != (int) HttpStatusCode.OK) return;

            context.Result = context.Result is ObjectResult objectResult
                ? new JsonResult(new ServiceResponseData<object>() {Data = objectResult.Value})
                : new JsonResult(ServiceResponseData.SuccessfulResponse());
        }

    }
}