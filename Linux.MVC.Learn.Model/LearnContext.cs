using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Linux.MVC.Learn.Model.Admin.Mapping;
using Linux.MVC.Learn.Model.Blog.Mapping;
using Linux.MVC.Learn.Model.Admin;
using Linux.MVC.Learn.Model.Blog;

namespace Linux.MVC.Learn.Model 
{
    public partial class LearnContext : DbContext
    {
        static LearnContext()
        {
            Database.SetInitializer<LearnContext>(null);
        }

        public LearnContext()
            : base("Name=learnContext")
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<UserDetial> UserDetials { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogTag> BlogTags { get; set; }

        public DbSet<BlogComment> BlogComments { get; set; }

        public DbSet<SpamShield> SpamShields { get; set; }

        public DbSet<SpamHash> SpamHashs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SysMenuMap());
            modelBuilder.Configurations.Add(new SysUserMap());
            modelBuilder.Configurations.Add(new UserDetialMap());
            modelBuilder.Configurations.Add(new BlogPostMap());
            modelBuilder.Configurations.Add(new BlogTagMap());
            modelBuilder.Configurations.Add(new BlogCommentMap());
            modelBuilder.Configurations.Add(new SpamShieldMap());
            modelBuilder.Configurations.Add(new SpamHashMap());
        }
    }
}
