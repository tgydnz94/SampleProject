using SampleProject.Core.Abstract;

namespace SampleProject.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        //Navigation Property

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }

}
