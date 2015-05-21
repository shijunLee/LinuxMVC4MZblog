using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.Model.Blog.Mapping
{
    public class BlogCommentMap : EntityTypeConfiguration<BlogComment>
    {
        public BlogCommentMap()
        {
            this.HasKey(p=>p.Id);
            this.Property(p => p.Id).IsRequired(); 
            this.Property(p => p.Content).IsRequired();
            this.Property(p => p.CreatedTime).IsRequired();
            this.Property(p => p.Email);
            this.Property(p=>p.IPAddress).IsRequired();
            this.Property(p => p.NickName);
            this.Property(p => p.PostId);
            this.Property(p => p.SiteUrl);
            this.ToTable("BlogComment", "learn");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Content).HasColumnName("Content");
            this.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
            this.Property(p => p.Email).HasColumnName("Email");
            this.Property(p => p.IPAddress).HasColumnName("IPAddress");
            this.Property(p => p.NickName).HasColumnName("NickName");
            this.Property(p => p.PostId).HasColumnName("PostId");
            this.Property(p => p.SiteUrl).HasColumnName("SiteUrl");

            // Relationships
          //  this.HasOptional(p => p.BlogPost).WithMany(p => p.Comments).HasForeignKey(p => p.PostId);
        }
    }
}
