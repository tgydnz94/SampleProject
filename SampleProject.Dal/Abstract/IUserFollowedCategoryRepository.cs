using SampleProject.Entities.Concrete;

namespace SampleProject.Dal.Abstract
{
    public interface IUserFollowedCategoryRepository
    {
        void Create(UserFollowedCategories entity);
        void Delete(UserFollowedCategories entity);
    }
}
