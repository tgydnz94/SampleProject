using SampleProject.Core.Entity.Abstract;
using System.Collections.Generic;

namespace SampleProject.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new List<Article>();
            UserFollowedCategories = new List<UserFollowedCategories>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        //Navigation Property

        public List<Article> Articles { get; set; }
        public List<UserFollowedCategories> UserFollowedCategories { get; set; }
    }

}
