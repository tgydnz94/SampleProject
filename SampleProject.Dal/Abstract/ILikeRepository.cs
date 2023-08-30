using SampleProject.Entities.Concrete;
using System;
using System.Linq.Expressions;

namespace SampleProject.Dal.Abstract
{
    public interface ILikeRepository
    {
        void Create(Like entity);
        void Delete(Like entity);
        Like GetDefault(Expression<Func<Like, bool>> expression);
    }
}
