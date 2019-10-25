using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLogin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DemoLogin.Controllers
{
    public class BaseController : Controller
    {
        protected DemoContext db;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Session.GetString("UserName");
            //ViewBag.Name = session;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else Redirect("/");

            base.OnActionExecuting(filterContext);
        }
    }
}