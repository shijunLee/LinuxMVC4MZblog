using Linux.MVC.Learn.DDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linux.MVC.Learn.GlobalFilter
{
    public class WebAppFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            List<ViewMessage> message = new List<ViewMessage>();
            filterContext.Controller.ViewBag.Messages = message; 
            base.OnActionExecuted(filterContext);
            if (filterContext.HttpContext.User.Identity == null)
            {
                RedirectResult result = new RedirectResult("~/Home/Index");
                result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
           
        }
    }
}