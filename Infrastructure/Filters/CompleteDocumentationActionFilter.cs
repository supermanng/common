using System.Linq;
using Etechnosoft.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Etechnosoft.Common.Infrastructure.Filters
{
    public class CompleteDocumentationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.Any(item => item is AuthorizeFilter)) return;
            if (context.Filters.Any(item => item is AllowAnonymousFilter)) return;
            if (context.Filters.Any(item => item is AllowIncompleteDocumentationAttribute)) return;
            var registrationStatus = context.HttpContext.User.Identity.GetRegistrationStatus();
            if (registrationStatus == RegistrationStatusEnum.Completed) return;
            context.Result = new ForbidResult();
        }
    }
}