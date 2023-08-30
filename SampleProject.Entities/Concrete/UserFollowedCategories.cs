namespace SampleProject.Entities.Concrete
{
    public class UserFollowedCategories
    {
        //Ara tablo olduğu için sql tarafında id verilmesini istemedik

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }

}
