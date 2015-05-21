using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Linux.MVC.Learn.Model.Blog.Mapping
{
    public class SpamHashMap:EntityTypeConfiguration<SpamHash>
    {
        public SpamHashMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
            this.Property(p => p.Hash).HasColumnName("Hash");
            this.Property(p => p.Pass).HasColumnName("Pass");
            this.Property(p => p.PostKey).HasColumnName("PostKey");
            this.Property(p => p.Id).HasColumnName("SpamHashId");
            this.ToTable("spamhash","learn");
        }
    }
}
