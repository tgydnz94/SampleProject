using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfCommentRepository : EfBaseRepository<Comment,ProjectContext>, ICommentRepository
    {
        public EfCommentRepository(ProjectContext context) : base(context)
        {

        }
    }
}
