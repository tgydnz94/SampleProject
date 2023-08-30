using Microsoft.EntityFrameworkCore;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfUserFollowedCategoryRepository : IUserFollowedCategoryRepository
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<UserFollowedCategories> _table;

        public EfUserFollowedCategoryRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _table = _projectContext.Set<UserFollowedCategories>();
        }

        public void Create(UserFollowedCategories entity)
        {
            _table.Add(entity);
            _projectContext.SaveChanges();
        }

        public void Delete(UserFollowedCategories entity)
        {
            _table.Remove(entity);
            _projectContext.SaveChanges();
        }
    }
}
