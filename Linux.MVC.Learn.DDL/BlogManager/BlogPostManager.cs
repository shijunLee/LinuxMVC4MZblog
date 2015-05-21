using Linux.MVC.Learn.Common;
using Linux.MVC.Learn.Common.Extensions;
using Linux.MVC.Learn.DDL.BindingModel;
using Linux.MVC.Learn.DDL.CommandModel;
using Linux.MVC.Learn.DDL.ViewModel;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.Model.Blog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.DDL.BlogManager
{
    /// <summary>
    /// 博客查询
    /// </summary>
    public class BlogPostManager
    {
        public AllBlogPostsViewModel GetBlogPostList(AllBlogPostsBindingModel input)
        {
            using (LearnContext context = new LearnContext())
            {
                var skip = (input.Page - 1) * input.Take;

                var posts = context.BlogPosts.OrderByDescending(p => p.DateUTC).Skip(skip).Take(input.Take + 1).ToList().AsReadOnly();
                var pagedPosts = posts.Take(input.Take);
                var hasNextPage = posts.Count > input.Take;
                return new AllBlogPostsViewModel
                {
                    Posts = pagedPosts,
                    Page = input.Page,
                    HasNextPage = hasNextPage
                };
            }
        }


        public bool DeleteBlogPost(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                using (LearnContext context = new LearnContext())
                { 
                    BlogPost post = context.BlogPosts.Where(p=>p.Id==id).SingleOrDefault();
                    if(post!=null)
                    {
                        context.BlogPosts.Remove(post);
                        context.SaveChanges();
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public BlogPost GetById(string id)
        {
            using (LearnContext context = new LearnContext())
            {
                BlogPost post = new BlogPost();
                if (!String.IsNullOrEmpty(id))
                {
                    post = context.BlogPosts.Include("Tags").Where(p => p.Id == id).SingleOrDefault();
                }
                return post;
            }
        }

        public BlogPostDetailsViewModel GetBlogDetails(BlogPostDetailsBindingModel input)
        {
            using (LearnContext context = new LearnContext())
            {
                BlogPost post = context.BlogPosts.Where(p => p.Id == input.Permalink).Include("Tags").Include("Comments").SingleOrDefault();
                if (post != null)
                {
                    return new BlogPostDetailsViewModel() { BlogPost=post, Comments=(post.Comments==null?new BlogComment[]{}: post.Comments.ToArray()) };
                }
            }

            return null;

        }

        public BlogPost SaveEditBlogPost(EditPostCommand command)
        {
            var markdown = new MarkdownSharp.Markdown();
            //TODO:应该验证TitleSlug是否唯一

            using (LearnContext context = new LearnContext())
            {
                if (command != null)
                {
                    var post = context.BlogPosts.Include("Tags").Where(s => s.Id == command.PostId).SingleOrDefault();
                    if (post == null)
                    {
                        return null;
                    }
                    //   if (!String.IsNullOrEmpty(command.))
                   // post.Id = Guid.NewGuid().ToString();
                   // post.AuthorEmail = command.Author.Email;
                   // post.AuthorDisplayName = command.Author.DisplayName;
                    post.MarkDown = command.MarkDown;
                    post.Content = markdown.Transform(command.MarkDown);
                    post.PubDate = command.PubDate.CloneToUtc();
                    post.Status = command.Published ? PublishStatus.Published : PublishStatus.Draft;
                    post.Title = command.Title;
                    post.TitleSlug = command.TitleSlug.IsNullOrWhitespace() ? command.Title.Trim().ToSlug() : command.TitleSlug.Trim().ToSlug();
                    post.DateUTC = DateTime.UtcNow;
                    if (!String.IsNullOrEmpty(command.Tags))
                    {
                        string[] tags = command.Tags.Split(',');
                        List<BlogTag> tagList = new List<BlogTag>();
                        foreach (var item in tags)
                        {
                            BlogTag tag = new BlogTag();
                            tag.BlogTagId = Guid.NewGuid().ToString();
                            tag.BlogPostId = post.Id;
                            tag.Tag = item;
                            tag.Slug = item.ToSlug();
                            tag.blogPost = post;
                            tagList.Add(tag);
                        }
                        if (post.Tags != null && post.Tags.Count > 0)
                        {
                            List<BlogTag> listTag =  context.BlogTags.Where(p => p.BlogPostId == command.PostId).ToList();
                            context.BlogTags.RemoveRange(listTag); 
                            post.Tags.Clear();

                        }
                        post.Tags = tagList;
                       
                    }
                    try
                    {
                     //   context.BlogPosts.Add(post);
                      //  context.Entry<BlogPost>(post).State = EntityState.Modified;
                        context.SaveChanges();
                        return post;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(BlogPostManager), ex);
                        return null;
                    }
                }
                else
                {
                    return  null;
                }
            }
        }

        /// <summary>
        /// 进行数据保存
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool SaveBlogPost(NewPostCommand command)
        {
            var markdown = new MarkdownSharp.Markdown();
            //TODO:应该验证TitleSlug是否唯一

            using (LearnContext context = new LearnContext())
            {
                if (command != null)
                {
                    var post = new BlogPost();
                    //   if (!String.IsNullOrEmpty(command.))
                    post.Id = Guid.NewGuid().ToString();
                    post.AuthorEmail = command.Author.Email;
                    post.AuthorDisplayName = command.Author.DisplayName;
                    post.MarkDown = command.MarkDown;
                    post.Content = markdown.Transform(command.MarkDown);
                    post.PubDate = command.PubDate.CloneToUtc();
                    post.Status = command.Published ? PublishStatus.Published : PublishStatus.Draft;
                    post.Title = command.Title;
                    post.TitleSlug = command.TitleSlug.IsNullOrWhitespace() ? command.Title.Trim().ToSlug() : command.TitleSlug.Trim().ToSlug();
                    post.DateUTC = DateTime.UtcNow;
                    if (!String.IsNullOrEmpty(command.Tags))
                    {
                        string[] tags = command.Tags.Split(',');
                        List<BlogTag> tagList = new List<BlogTag>();
                        foreach (var item in tags)
                        {
                            BlogTag tag = new BlogTag();
                            tag.BlogTagId = Guid.NewGuid().ToString();
                            tag.BlogPostId = post.Id; 
                            tag.Tag = item;
                            tag.blogPost = post;
                            tagList.Add(tag);
                        }
                        post.Tags = tagList;
                    }
                    try
                    {
                        context.BlogPosts.Add(post);
                        context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(BlogPostManager), ex);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

    }
}
