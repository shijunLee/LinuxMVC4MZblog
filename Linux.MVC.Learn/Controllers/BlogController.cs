using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Linux.MVC.Learn.DDL.BlogManager;
using Linux.MVC.Learn.DDL.ViewModel;

namespace Linux.MVC.Learn.Controllers
{
    public class BlogController : BaseController
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            AllStatisticsViewModel model = new AllStatisticsViewModel();
            AdminIndex indexManager = new AdminIndex();
            model = indexManager.GetBlogStatistics();
         
            return View(model);
        }


        public ActionResult ReturnHomeAction()
        {
            return View();
        }
    }
}
