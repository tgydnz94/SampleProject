using System;

namespace SampleProject.Web.Models.VMs
{
    public class GetArticleWithUserVM
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int ArticleID { get; set; }

        public string Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AppUserID { get; set; }

        public string UserFullName { get; set; }
    }
}
