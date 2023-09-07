using SampleProject.Entities.Concrete;
using System.Collections.Generic;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class CreateCommentVM
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int AppUserID { get; set; }
        public int ArticleID { get; set; }
        public List<Article> Articles { get; set; }
    }
}
