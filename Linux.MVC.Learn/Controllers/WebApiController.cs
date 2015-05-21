using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.Model.Admin;

namespace Linux.MVC.Learn.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public string Delete(string id)
        {
            List<SysUser> userList = new List<SysUser>();
            using (LearnContext dbContext = new LearnContext())
            {
                SysUser user = dbContext.SysUsers.Where(p => p.UserID == id).SingleOrDefault();
                if (user != null)
                {
                    dbContext.SysUsers.Remove(user);
                    dbContext.SaveChanges();
                }
                userList = dbContext.SysUsers.ToList();
            }
            return "secuess";
        } 
    }
}
