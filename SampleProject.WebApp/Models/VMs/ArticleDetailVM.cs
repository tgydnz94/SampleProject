using SampleProject.Entities.Concrete;
using System.Collections.Generic;
using System;

namespace SampleProject.WebApp.Models.VMs
{
    public class ArticleDetailVM
    {
        // ARTİCLE

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ArticleId { get; set; }

        public List<Like> Likes { get; set; }


        // category

        public string CategoryName { get; set; }

        // user

        public int UserId { get; set; }

        public string UserFullName { get; set; }

        public string UserImage { get; set; }



    }
}
