using Linux.MVC.Learn.Common;
using Linux.MVC.Learn.DDL.UserManager;
using Linux.MVC.Learn.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Linux.MVC.Learn.Controllers
{
    public class AdminController : Controller
    {
        // GET: / Home/Index
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {

            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }


        //
        // POST: /Login/Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SysUser user, string ReturnUrl)
        {

            UserManager manager = new UserManager();
            LogHelper.WriteLog(typeof(String), "this is a test" + user.UserLoginName);
            bool result = manager.UserLogin(user.UserLoginName, user.Password);

            if (result)
            {
                // SysUser loginUser = new SysUser();
                FormsAuthentication.SetAuthCookie(user.UserLoginName, true);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserLoginName,
                    DateTime.Now, DateTime.Now.AddMinutes(30), false, "", "/");
                string HashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);

                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Cookies.Add(UserCookie);
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }

            }
            else
            {
                ViewBag.ErrorMessage = "用户名和密码错误请重新登陆！";
                return RedirectToAction("Index", "Admin");
            }

        }

    }
}
