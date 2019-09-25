using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            byte[] sessionValue;
            if (!context.HttpContext.Session.TryGetValue("auth_phone_key",out sessionValue))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"controller","Login" },
                        {"action","Index" }
                    });
            }
            base.OnActionExecuting(context);
        }
    }
}
