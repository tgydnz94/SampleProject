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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public bool Any(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepository.Any(expression);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        [CacheRemoveAspect("ICategoryService.Get")]

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<Category, TResult>> selector, Expression<Func<Category, bool>> expression, Func<IQueryable<Category>, IIncludableQueryable<Category, object>> include = null)
        {
            return _categoryRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<Category, TResult>> selector, Expression<Func<Category, bool>> expression, Func<IQueryable<Category>, IIncludableQueryable<Category, object>> include = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null)
        {

            return _categoryRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        public List<Category> GetCategoriesWithUser(int id)
        {
            return _categoryRepository.GetCategoriesWithUser(id);
        }

        [CacheAspect]

        public Category GetDefault(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepository.GetDefault(expression);
        }

        [CacheAspect]

        public List<Category> GetDefaults(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepository.GetDefaults(expression);
        }

        [CacheRemoveAspect("ICategoryService.Get")]

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
