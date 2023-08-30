using Microsoft.EntityFrameworkCore.Query;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using SampleProject.Dal.Abstract;

namespace SampleProject.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public bool Any(Expression<Func<Comment, bool>> expression)
        {
            return _commentRepository.Any(expression);
        }

        public void Create(Comment entity)
        {
            _commentRepository.Create(entity);
        }

        public void Delete(Comment entity)
        {
            _commentRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<Comment, TResult>> selector, Expression<Func<Comment, bool>> expression, Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>> include = null)
        {
            return _commentRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<Comment, TResult>> selector, Expression<Func<Comment, bool>> expression, Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>> include = null, Func<IQueryable<Comment>, IOrderedQueryable<Comment>> orderBy = null)
        {
            return _commentRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        public Comment GetDefault(Expression<Func<Comment, bool>> expression)
        {
            return _commentRepository.GetDefault(expression);
        }

        public List<Comment> GetDefaults(Expression<Func<Comment, bool>> expression)
        {
            return _commentRepository.GetDefaults(expression);
        }

        public void Update(Comment entity)
        {
            _commentRepository.Update(entity);
        }
    }
}
