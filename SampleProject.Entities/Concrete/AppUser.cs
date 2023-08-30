using Microsoft.AspNetCore.Http;
using SampleProject.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleProject.Entities.Concrete
{
    public class AppUser : BaseEntity
    {
        public AppUser()
        {
            Articles = new List<Article>();
            Likes = new List<Like>();
            Comments = new List<Comment>();
            UserFollowedCategories = new List<UserFollowedCategories>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Image { get; set; }

        [NotMapped] //Bu property veritabanında kaydolmayacak
        public IFormFile ImagePath { get; set; }
        public string IdentityId { get; set; }

        //Navigation Property

        public List<Article> Articles { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UserFollowedCategories> UserFollowedCategories { get; set; }
    }

}
