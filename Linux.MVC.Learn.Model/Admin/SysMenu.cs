using System;
using System.Collections.Generic;

namespace Linux.MVC.Learn.Model.Admin
{
    public partial class SysMenu
    {
        public SysMenu()
        {
            this.roles = new List<Role>();
        }

        public string SysMenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuRemark { get; set; }
        public virtual ICollection<Role> roles { get; set; }
    }
}
