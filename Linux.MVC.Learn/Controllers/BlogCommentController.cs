using Linux.MVC.Learn.DDL.BlogManager;
using Linux.MVC.Learn.DDL.ViewModel;
using Linux.MVC.Learn.DDL.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Linux.MVC.Learn.DDL.CommandModel;
using Linux.MVC.Learn.Model.Blog;

namespace Linux.MVC.Learn.Controllers
{
    public class BlogCommentController : Controller
    {
        //
        // GET: /BlogComment/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetList(int page =1)
        {
            BlogCommentManage manager = new BlogCommentManage();
            AllBlogCommentsViewModel model = new AllBlogCommentsViewModel();
            model = manager.GetAll(new AllBlogCommentsBindingModel()
                    {
                        Page = page
                    });
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                BlogCommentManage manager = new BlogCommentManage();
                manager.DeleteBlogComment(id);
            }

            return RedirectToAction("GetList", "BlogComment");
        }

        public ActionResult AddComment(NewCommentCommand command,SpamShield spam)
        {
            command.SpamShield = spam;
            command.IPAddress = Request.UserHostAddress;
           
            BlogCommentManage manager = new BlogCommentManage();
            manager.SaveNewBlogComment(command);
            return RedirectToAction("Details", "Home", new { id = command.PostId });
        }
    }
}
