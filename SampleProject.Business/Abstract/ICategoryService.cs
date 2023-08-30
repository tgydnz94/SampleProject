using SampleProject.Core.Business;
using SampleProject.Entities.Concrete;
using System.Collections.Generic;

namespace SampleProject.Business.Abstract
{
    public interface ICategoryService : IGenericBus<Category>
    {
        List<Category> GetCategoriesWithUser(int id);
    }
}
