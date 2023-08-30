namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class GetArticleVM
    {

        // ARTICLE

        public int ArticleID { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }


        // Category

        public string CategoryName { get; set; }

        // AppUser

        public string FullName { get; set; }

    }
}
