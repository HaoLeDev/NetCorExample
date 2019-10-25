using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Mvc.Core.Models;

namespace Mvc.Core.Controllers
{
    public class BaseController : Controller
    {
        protected PersonTestContext db;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Session.GetString("UserName");
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}