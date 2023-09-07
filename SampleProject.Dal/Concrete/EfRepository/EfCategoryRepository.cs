using Microsoft.EntityFrameworkCore;
using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfCategoryRepository : EfBaseRepository<Category,ProjectContext>, ICategoryRepository
    {
        private readonly ProjectContext _context;
        public EfCategoryRepository(ProjectContext context) : base(context)
        {
            _context=context;
        }

        public List<Category> GetCategoriesWithUser(int id)
        {

            return _context.UserFollowedCategories.Include(a => a.AppUser).Include(a => a.Category).Where(a => a.AppUserID == id).Select(a => a.Category).ToList();
        }
    }
}
