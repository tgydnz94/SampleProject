using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using System.Text;
using SampleProject.Dal.Abstract;

namespace SampleProject.Business.Concrete
{
    public class UserFollowedCategoryManager : IUserFollowedCategoryService
    {
        private readonly IUserFollowedCategoryRepository _userFollowedCategoryRepository;

        public UserFollowedCategoryManager(IUserFollowedCategoryRepository userFollowedCategoryRepository)
        {
            _userFollowedCategoryRepository = userFollowedCategoryRepository;
        }

        public void Create(UserFollowedCategories entity)
        {
            _userFollowedCategoryRepository.Create(entity);
        }

        public void Delete(UserFollowedCategories entity)
        {
            _userFollowedCategoryRepository.Delete(entity);
        }
    }
}
