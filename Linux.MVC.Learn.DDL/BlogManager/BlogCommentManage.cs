﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linux.MVC.Learn.Common;
using Linux.MVC.Learn.Common.Extensions;
using Linux.MVC.Learn.DDL.BindingModel;
using Linux.MVC.Learn.DDL.CommandModel;
using Linux.MVC.Learn.DDL.ViewModel;
using Linux.MVC.Learn.Model;
using Linux.MVC.Learn.Model.Blog;

namespace Linux.MVC.Learn.DDL.BlogManager
{
    public class BlogCommentManage
    {
        public AllBlogCommentsViewModel GetAll(AllBlogCommentsBindingModel input)
        { 
            List<BlogComment> commentList = new List<BlogComment>();
            using (LearnContext context = new LearnContext())
            {
                var skip = (input.Page - 1) * input.Take;
                commentList = context.BlogComments.OrderByDescending(p => p.CreatedTime)
                    .Skip(skip).Take(input.Take + 1).ToList();
                var pagedComments = commentList.Take(input.Take);
                var hasNextPage = commentList.Count > input.Take;
                return new AllBlogCommentsViewModel
                {
                    Comments = pagedComments,
                    Page = input.Page,
                    HasNextPage = hasNextPage
                };
            } 
        }

        public bool DeleteBlogComment(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                using (LearnContext context = new LearnContext())
                {
                    BlogComment comment = context.BlogComments.Where(p => p.Id == id).SingleOrDefault();
                    if (comment != null)
                    {
                        context.BlogComments.Remove(comment);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool SaveNewBlogComment(NewCommentCommand command)
        {
            ISpamShieldService service = new SpamShieldService();

            if(service.IsSpam(command.SpamShield))
            {
                return false;
            }
            if (command != null)
            {
                using (LearnContext context = new LearnContext())
                {
                    var comment = new BlogComment
                    {
                        Id = command.Id,
                        Email = command.Email,
                        NickName = command.NickName,
                        Content = command.Content,
                        IPAddress = command.IPAddress,
                        PostId = command.PostId,
                        SiteUrl = command.SiteUrl,
                        CreatedTime = DateTime.UtcNow
                    };
                    context.BlogComments.Add(comment);
                    context.SaveChanges();
                    return true;
                }
            
            }
            return false;
        }
    }
}
