using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Core.Business;
using Mvc.Core.Models;

namespace Mvc.Core.Controllers
{
    public class LoginController : Controller
    {
        private PersonTestContext db = new PersonTestContext();
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Validate(Account account)
        {
            var _account = db.Account.Where(a => a.UserName == account.UserName);
            if (_account.Any())
            {
                var accountBiz = new AccountBiz();
                if(_account.Where(a=>a.Password == account.Password).Any())
                {
                    var user = accountBiz.GetbyId(account.UserName);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index");
                    //return Json(new { status = false, message = "Mật khẩu không chính xác!" });
                }
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult DangNhap(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var accountBiz = new AccountBiz();
                var result = accountBiz.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = accountBiz.GetbyId(model.UserName);
                    var userSession = new Account();
                    userSession.UserName = user.UserName;
                    userSession.Password = user.Password;
                    HttpContext.Session.SetString(userSession.UserName, "UserName");
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    return Json(new { status = false, message = "Tài khoản không chính xác!" });
                }
                else if (result == -1)
                {
                    return Json(new { status = false, message = "Tài khoản đang bị khóa" });
                }
                else if (result == -2)
                {
                    return Json(new { status = false, message = "Mật khẩu không chính xác!" });
                }
            }
            return View("Index");
            
        }
        
    }
}