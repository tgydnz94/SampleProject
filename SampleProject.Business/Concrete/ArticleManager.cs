using Microsoft.EntityFrameworkCore.Query;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using SampleProject.Dal.Abstract;
using SampleProject.Core.Aspects.Autofac.Validation;
using SampleProject.Business.ValidationRules.FluentValidation;
using SampleProject.Core.Aspects.Autofac.Caching;

namespace SampleProject.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public bool Any(Expression<Func<Article, bool>> expression)
        {
            return _articleRepository.Any(expression);
        }

        [ValidationAspect(typeof(ArticleValidator))]
        [CacheRemoveAspect("IArticleService.Get")]

        public void Create(Article entity)
        {
            _articleRepository.Create(entity);
        }

        [CacheRemoveAspect("IArticleService.Get")]

        public void Delete(Article entity)
        {
            _articleRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<Article, TResult>> selector, Expression<Func<Article, bool>> expression, Func<IQueryable<Article>, IIncludableQueryable<Article, object>> include = null)
        {
            return _articleRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<Article, TResult>> selector, Expression<Func<Article, bool>> expression, Func<IQueryable<Article>, IIncludableQueryable<Article, object>> include = null, Func<IQueryable<Article>, IOrderedQueryable<Article>> orderBy = null)
        {
            return _articleRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        [CacheAspect]
        public Article GetDefault(Expression<Func<Article, bool>> expression)
        {
            return _articleRepository.GetDefault(expression);
        }

        [CacheAspect]
        public List<Article> GetDefaults(Expression<Func<Article, bool>> expression)
        {
            return _articleRepository.GetDefaults(expression);
        }

        [CacheRemoveAspect("IArticleService.Get")]
        public void Update(Article entity)
        {
            _articleRepository.Update(entity);
        }
    }
}
