using SampleProject.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace SampleProject.Business.Abstract
{
    public interface ILikeService
    {
        void Create(Like entity);
        void Delete(Like entity);
        Like GetDefault(Expression<Func<Like, bool>> expression);
    }
}
