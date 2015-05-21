using System.Web;
using System.Web.Mvc;
using Linux.MVC.Learn.GlobalFilter;


namespace Linux.MVC.Learn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new WebAppFilter());
        }
    }
}