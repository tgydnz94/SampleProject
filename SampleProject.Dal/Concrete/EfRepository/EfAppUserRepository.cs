using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;
using System.Text;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfAppUserRepository : EfBaseRepository<AppUser, ProjectContext>, IAppUserRepository
    {

        public EfAppUserRepository(ProjectContext context) : base(context)
        {

        }
    }
}
