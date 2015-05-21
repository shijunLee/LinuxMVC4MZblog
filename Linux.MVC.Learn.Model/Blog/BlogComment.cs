﻿using Linux.MVC.Learn.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MVC.Learn.Model.Blog
{
    public class BlogComment
    {
        public string Id { get; set; }

         
        public string Content { get; set; }

        
        public string NickName { get; set; }

         
        public string Email { get; set; }

        public string SiteUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public string PostId { get; set; }

        public string IPAddress { get; set; }

        public BlogPost BlogPost { get; set; }

        public string Avatar
        {
            get
            {
                var imgUrl = string.Format("https://secure.gravatar.com/avatar/{0}.png?s={1}&d={2}&r=g", Hasher.GetMd5Hash(Email), 60, "mm");
                return imgUrl;
            }
        }
    }
}
