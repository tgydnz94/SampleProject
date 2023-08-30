using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfArticleRepository : EfBaseRepository<Article, ProjectContext>, IArticleRepository
    {
        public EfArticleRepository(ProjectContext context) : base(context)
        {

        }
    }
}
