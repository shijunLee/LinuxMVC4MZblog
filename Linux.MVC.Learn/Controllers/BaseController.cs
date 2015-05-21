using Linux.MVC.Learn.Model.Admin;
using Linux.MVC.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linux.MVC.Learn.Controllers
{
    /// <summary>
    /// 控制Controller 基类进行方法添加集成 使用公用的权限方法判断
    /// </summary>
    public class BaseController : Controller
    {
        public Author author;
        public BaseController()
            : base()
        {

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                Role role = new Role();
                List<Role> roles = new List<Role>();
                roles.Add(role);
                this.author = new Author { DisplayName = "李士军", Email = "lishjun01@126.com", Id = "test", Roles = roles, HashedPassword = "test" };
                filterContext.Controller.ViewBag.Author = author;
            }
            else { 
                Response.RedirectToRoute(new { controller = "Admin", action = "Index", ReturnUrl = Request.Url.ToString()});

            }
        }

    }
}