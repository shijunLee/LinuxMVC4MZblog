using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.DDL.BindingModel
{
    public class TagCloudBindingModel
    {
        public int Threshold { get; set; }

        public int Take { get; set; }

        public TagCloudBindingModel()
        {
            Threshold = 1;
            Take = int.MaxValue;
        }
    }
}
