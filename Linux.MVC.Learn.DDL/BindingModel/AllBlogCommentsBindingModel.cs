using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.DDL.BindingModel
{
    public class AllBlogCommentsBindingModel
    {
        public AllBlogCommentsBindingModel()
        {
            Page = 1;
            Take = 20;
        }

        public int Page { get; set; }

        public int Take { get; set; }
    }
}
