using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.Model.Blog.Mapping
{
    public class SpamShieldMap: EntityTypeConfiguration<SpamShield>
    {
        public SpamShieldMap()
        {
            this.HasKey(p => p.Tick);
            this.Property(p => p.Tick).IsRequired().HasColumnName("Tick");
            this.Property(p => p.Hash).IsRequired().HasColumnName("Hash");
            this.ToTable("SpamShield", "learn");
        }
    }
}
