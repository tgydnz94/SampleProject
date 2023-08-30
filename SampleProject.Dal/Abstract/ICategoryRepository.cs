using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Entities.Concrete;
using System.Collections.Generic;

namespace SampleProject.Dal.Abstract
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        List<Category> GetCategoriesWithUser(int id);
    }
}
