using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Linq.Expressions;
using SampleProject.Dal.Abstract;

namespace SampleProject.Business.Concrete
{
    public class LikeManager : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeManager(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public void Create(Like entity)
        {
            _likeRepository.Create(entity);
        }

        public void Delete(Like entity)
        {
            _likeRepository.Delete(entity);
        }

        public Like GetDefault(Expression<Func<Like, bool>> expression)
        {
            return _likeRepository.GetDefault(expression);
        }
    }
}
