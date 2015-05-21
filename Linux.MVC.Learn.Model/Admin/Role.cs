using System;
using System.Collections.Generic;

namespace Linux.MVC.Learn.Model.Admin
{
    public partial class Role
    {
        public Role()
        {
            this.sysmenus = new List<SysMenu>();
            this.sysusers = new List<SysUser>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleRemark { get; set; }
        public virtual ICollection<SysMenu> sysmenus { get; set; }
        public virtual ICollection<SysUser> sysusers { get; set; }
    }
}
