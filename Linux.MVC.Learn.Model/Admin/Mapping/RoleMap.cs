using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Admin.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.RoleId)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(t => t.RoleName)
                .HasMaxLength(254);

            this.Property(t => t.RoleRemark)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("role", "learn");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.RoleRemark).HasColumnName("RoleRemark");

            // Relationships
            this.HasMany(t => t.sysmenus)
                .WithMany(t => t.roles)
                .Map(m =>
                    {
                        m.ToTable("rolesysmenu", "learn");
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("SysMenuId");
                    });

            this.HasMany(t => t.sysusers)
                .WithMany(t => t.roles)
                .Map(m =>
                    {
                        m.ToTable("userrole", "learn");
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("UserID");
                    });


        }
    }
}
