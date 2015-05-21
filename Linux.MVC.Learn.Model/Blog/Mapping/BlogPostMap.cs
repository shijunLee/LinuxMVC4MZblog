using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.Model.Blog.Mapping
{
    public class BlogPostMap : EntityTypeConfiguration<BlogPost>
    {
        public BlogPostMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).IsRequired();
            //this.not(p => p.IsPublished).IsRequired();
            this.Property(p => p.PubDate).IsRequired(); 
            this.Property(p => p.AuthorDisplayName).IsRequired() ;
            this.Property(p => p.AuthorEmail).IsRequired();
            this.Property(p => p.Content).IsRequired();
            this.Property(p => p.DateUTC);
            //this.Property(p => p.Description);
            this.Property(p => p.MarkDown);
            this.Property(p => p.Status).IsRequired();
            //this.Property(p => p.Tags).IsRequired();
            this.Property(p => p.Title).IsRequired();
            this.Property(p => p.TitleSlug).IsRequired();
            this.Property(p=>p.ViewCount);

            // Table & Column Mappings
            this.ToTable("BlogPost", "learn");
            this.Property(t => t.Id).HasColumnName("BlogId");
            this.Property(t => t.PubDate).HasColumnName("PubDate");
            this.Property(t => t.AuthorDisplayName).HasColumnName("AuthorDisplayName");
            this.Property(t => t.AuthorEmail).HasColumnName("AuthorEmail");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.DateUTC).HasColumnName("DateUTC");
            this.Property(t => t.MarkDown).HasColumnName("MarkDown");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TitleSlug).HasColumnName("TitleSlug"); 
            this.Property(t => t.ViewCount).HasColumnName("ViewCount");
            // Relationships
            this.HasMany(t => t.Tags).WithRequired(p => p.blogPost).HasForeignKey(p=>p.BlogPostId).WillCascadeOnDelete();
            this.HasMany(t => t.Comments).WithRequired(p => p.BlogPost).HasForeignKey(p=>p.PostId).WillCascadeOnDelete();
          

        }
    }
}
