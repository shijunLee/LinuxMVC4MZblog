using Linux.MVC.Learn.DDL.BindingModel;
using Linux.MVC.Learn.DDL.BlogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linux.MVC.Learn.Controllers
{
    public class FrontBaseController:Controller
    {
        public FrontBaseController()
            : base()
        {

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HomeMainManager manager = new HomeMainManager();
            ViewBag.Recent = manager.GetRecentBlogPostSummaryView( new RecentBlogPostSummaryBindingModel { Page = 10 });
            BlogTagManage tagManager = new BlogTagManage();

            ViewBag.TagCould = tagManager.GetAll(new TagCloudBindingModel() { Threshold = 2 });
        }
    }
}