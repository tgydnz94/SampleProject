using System.Collections.Generic;
using SampleProject.Entities.Concrete;
using System;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class ArticleDetailVM
    {
        // ARTICLE 
        public int ArticleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Like> Likes { get; set; }


        // CATEGORY

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        // APPUSER

        public int UserId { get; set; }

        public string UserFullName { get; set; }

        public string UserImage { get; set; }

        public DateTime UserCreatedDate { get; set; }


        // yorumlar ??  // todo:

    }
}
