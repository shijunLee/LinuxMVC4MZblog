using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Admin.Mapping
{
    public class UserDetialMap : EntityTypeConfiguration<UserDetial>
    {
        public UserDetialMap()
        {
            // Primary Key
            this.HasKey(t => t.UserDetialId);

            // Properties
            this.Property(t => t.UserDetialId)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(t => t.UserID)
                .HasMaxLength(254);

            this.Property(t => t.UserName)
                .HasMaxLength(254);

            this.Property(t => t.Phone)
                .HasMaxLength(254);

            this.Property(t => t.Email)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("userdetial", "learn");
            this.Property(t => t.UserDetialId).HasColumnName("UserDetialId");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");

            // Relationships
            this.HasOptional(t => t.sysuser)
                .WithMany(t => t.userdetials)
                .HasForeignKey(d => d.UserID);

        }
    }
}
