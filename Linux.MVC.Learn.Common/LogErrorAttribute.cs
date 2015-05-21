using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Linux.MVC.Learn.Common
{
    /// <summary>
    /// 异常日志
    /// </summary>
    public class LogErrorAttribute : HandleErrorAttribute
    {
        //public 
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogHelper.WriteLog(filterContext.GetType(), filterContext.Exception);

        }
    }
}
