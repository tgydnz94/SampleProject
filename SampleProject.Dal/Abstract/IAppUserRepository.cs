using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Entities.Concrete;
using System.Text;

namespace SampleProject.Dal.Abstract
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
    }
}
