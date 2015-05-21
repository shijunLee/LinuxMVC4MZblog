using Linux.MVC.Learn.DDL.BindingModel;
using Linux.MVC.Learn.DDL.ViewModel;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.DDL.BlogManager
{
    public class BlogTagManage
    {
        public TagCloudViewModel GetAll(TagCloudBindingModel input)
        {
            using (LearnContext context = new LearnContext())
            { 
               List<BlogTagViewModel> list =
                context.BlogTags.GroupBy(p => new { p.Tag, p.Slug }).
                Select(group => new BlogTagViewModel(){ Name=group.Key.Tag, Slug=group.Key.Slug, PostCount=group.Count() })
                .ToList();
               if (list != null && list.Count > 0)
               {
                   return new TagCloudViewModel()
                   {
                       Tags = list
                   };
               }
            }
            return null;
        }

        public TaggedBlogPostsViewModel GetPostByTag(TaggedBlogPostsBindingModel input)
        {
            using (LearnContext context = new LearnContext())
            {
                var blogs = context.BlogPosts.Include("Tags")
                    .Where(p => p.Tags.Any(t => t.Tag == input.Tag))
                    .Where(p => p.Status == (int)PublishStatus.Published)
                    .OrderByDescending(p=>p.PubDate).ToList();
                if (blogs.Count == 0)
                    return null;
                return new TaggedBlogPostsViewModel
                {
                    Posts = blogs,
                    Tag = input.Tag
                }; 
            } 
        }
    }
}
