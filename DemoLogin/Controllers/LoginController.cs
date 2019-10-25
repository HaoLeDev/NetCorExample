using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLogin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        DemoContext db = new DemoContext();
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(Account admin)
        {
            var _admin = db.Accounts.Where(s => s.UserName == admin.UserName);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password == admin.Password).Any())
                {
                    HttpContext.Session.SetString("UserName",admin.UserName);
                    return Json(new { status = true, message = "Đăng nhập thành công" });
                }
                else
                {
                    return Json(new { status = false, message = "Mật khẩu không chính xác!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Tên đăng nhập không chính xác" });
            }
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            return View("Index");
        }
    }
}