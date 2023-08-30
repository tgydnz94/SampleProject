using System;

namespace SampleProject.Web.Models.VMs
{
    public class GetCommentWithUserVM
    {
        public string Text { get; set; }
        public int AppUserID { get; set; }
        public int ArticleID { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }

    }
}
