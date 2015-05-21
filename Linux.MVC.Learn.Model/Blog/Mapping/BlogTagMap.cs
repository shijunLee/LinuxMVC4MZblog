using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Blog.Mapping
{
    public class BlogTagMap : EntityTypeConfiguration<BlogTag>
    {
        public BlogTagMap()
        {
            this.HasKey(p => p.BlogTagId);
            this.Property(p => p.Tag).IsRequired();
            this.Property(p => p.BlogPostId);
            this.Property(p => p.BlogTagId).IsRequired();
            this.Property(p=>p.Slug);
            // Table & Column Mappings
            this.ToTable("BlogTag", "learn");
            this.Property(t => t.BlogTagId).HasColumnName("BlogTagId");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.BlogPostId).HasColumnName("BlogPostId");
            this.Property(t => t.Slug).HasColumnName("Slug");

            // Relationships
         //   this.HasOptional(p => p.blogPost).WithMany(p => p.Tags).HasForeignKey(p => p.BlogPostId);

        }
    }
}
