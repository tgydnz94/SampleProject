using Microsoft.AspNetCore.Http;
using SampleProject.Core.Entity.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Entities.Concrete
{
    public class Article : BaseEntity
    {
        public Article()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        [NotMapped]

        public IFormFile ImagePath { get; set; }

        //Navigation property

        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }

}
