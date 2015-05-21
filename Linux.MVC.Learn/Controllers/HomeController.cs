using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Linux.MVC.Learn.Model.Admin;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.DDL.UserManager;
using System.Web.Security;
using Linux.MVC.Learn.Common;
using Linux.MVC.Learn.DDL.BindingModel;
using Linux.MVC.Learn.DDL.BlogManager;
using Linux.MVC.Learn.DDL.ViewModel;
using System.Net;
using System.Collections;

namespace Linux.MVC.Learn.Controllers
{
    public class HomeController : FrontBaseController
    {

        public ActionResult KinderEditerTest()
        {
            return View();
        }


        public JsonResult UploadPicture()
        {
            string upresult = "";
            HttpPostedFileBase imgFile = this.HttpContext.Request.Files["imgFile"];
             Hashtable extTable = new Hashtable();
		    extTable.Add("image", "gif,jpg,jpeg,png,bmp");
		    extTable.Add("flash", "swf,flv");
		    extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
		    extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");
         //   JsonResult result = new JsonResult();
          //  result.Data = new {  };
            //hash["error"] = 0;
            //hash["url"] = fileUrl;
            return Json(new { error = 0, url = this.Request.ApplicationPath+@"/Content/images/ymz.jpg" }, "text/html; charset=UTF-8"); ;
        }

        public ActionResult Details(string id = "")
        {
            ISpamShieldService service = new SpamShieldService();
            BlogPostManager manager = new BlogPostManager();
            BlogPostDetailsViewModel model = manager.GetBlogDetails(new BlogPostDetailsBindingModel() { Permalink = id });
            ViewBag.Title = model.BlogPost.Title;

            ViewBag.Tick = service.CreateTick(id);
            return View(model);
        }

        public ActionResult Spamhash(string id)
        {
            ISpamShieldService service = new SpamShieldService();
            string result =  service.GenerateHash(id);
            return Content(result);
        }
     
        public ActionResult Index(int page = 1)
        {
            HomeMainManager homeMainManager = new HomeMainManager();
            RecentBlogPostsViewModel model = homeMainManager.GetRecentBlogPosts(new RecentBlogPostsBindingModel() { Page = page,Take=10 });
            if (model.Posts.Count() == 0)
            {
                if (page > 1)
                    return Content("程序出现错误!", "text/html; charset=utf-8");
                else
                    return Content("MZBlog尚未发现任何已经发布的文章哦!", "text/html; charset=utf-8");
            }
            if (page == 1)
                ViewBag.Title = "首页";
            else
                ViewBag.Title = "文章列表"; 
            return View(model);

        }

        public ActionResult Tag(string id)
        {
            BlogTagManage manager = new BlogTagManage();
            var result = manager.GetPostByTag(new TaggedBlogPostsBindingModel() { Tag = id });
            return View(result);
        }
    }
}
