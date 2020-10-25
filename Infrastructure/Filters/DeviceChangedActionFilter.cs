using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Etechnosoft.Common.Infrastructure.Filters
{
    public class DeviceChangedActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.Any(item => item is AuthorizeFilter)) return;
            if (context.Filters.Any(item => item is AllowAnonymousFilter)) return;
            if (context.Filters.Any(item => item is AllowSwitchDeivceAttribute)) return;
            var switchDevice = context.HttpContext.User.Identity.GetDeviceChanged();
            if (!switchDevice) return;
            context.Result = new ForbidResult();
        }
    }
}