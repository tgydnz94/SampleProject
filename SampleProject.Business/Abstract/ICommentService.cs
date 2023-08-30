using SampleProject.Core.Business;
using SampleProject.Entities.Concrete;

namespace SampleProject.Business.Abstract
{
    public interface ICommentService : IGenericBus<Comment>
    {
    }
}
