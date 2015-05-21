using Linux.MVC.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.DDL.ViewModel
{
    public class TagCloudViewModel
    {
        public IEnumerable<BlogTagViewModel> Tags { get; set; }
    }
}
