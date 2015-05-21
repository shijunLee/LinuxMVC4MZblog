using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Linux.MVC.Learn.DDL.BlogManager;
using Linux.MVC.Learn.DDL.ViewModel;

namespace Linux.MVC.Learn.Controllers
{
    public class BlogTagController : Controller
    {
        //
        // GET: /BlogTag/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page=0)
        {
            TagCloudViewModel model = new TagCloudViewModel();
            BlogTagManage manager = new BlogTagManage();
            model = manager.GetAll(null);
            return View(model);
        }

    }
}
