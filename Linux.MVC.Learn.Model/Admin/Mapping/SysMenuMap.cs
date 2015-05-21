using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Admin.Mapping
{
    public class SysMenuMap : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.SysMenuId);

            // Properties
            this.Property(t => t.SysMenuId)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(t => t.MenuName)
                .HasMaxLength(254);

            this.Property(t => t.MenuUrl)
                .HasMaxLength(254);

            this.Property(t => t.MenuRemark)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("sysmenu", "learn");
            this.Property(t => t.SysMenuId).HasColumnName("SysMenuId");
            this.Property(t => t.MenuName).HasColumnName("MenuName");
            this.Property(t => t.MenuUrl).HasColumnName("MenuUrl");
            this.Property(t => t.MenuRemark).HasColumnName("MenuRemark");
        }
    }
}
