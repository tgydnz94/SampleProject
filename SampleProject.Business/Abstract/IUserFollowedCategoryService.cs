using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Abstract
{
    public interface IUserFollowedCategoryService
    {
        void Create(UserFollowedCategories entity);
        void Delete(UserFollowedCategories entity);
    }
}
