using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Admin.Mapping
{
    public class SysUserMap : EntityTypeConfiguration<SysUser>
    {
        public SysUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(t => t.UserLoginName)
                .HasMaxLength(254);

            this.Property(t => t.Password)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("sysuser", "learn");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserLoginName).HasColumnName("UserLoginName");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}
