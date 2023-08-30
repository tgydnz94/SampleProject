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

namespace SampleProject.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        //private readonly DbSet<AppUser> _table;

        public AppUserManager(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
            //_table=context.Set<AppUser>();
        }
        public bool Any(Expression<Func<AppUser, bool>> expression)
        {
            return _appUserRepository.Any(expression);
        }

        [ValidationAspect(typeof(AppUserValidator))]

        public void Create(AppUser entity)
        {
            _appUserRepository.Create(entity);
        }

        public void Delete(AppUser entity)
        {
            _appUserRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<AppUser, TResult>> selector, Expression<Func<AppUser, bool>> expression, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>> include = null)
        {
            //IQueryable<AppUser> query = _table;
            return _appUserRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<AppUser, TResult>> selector, Expression<Func<AppUser, bool>> expression, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>> include = null, Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = null)
        {
            //IQueryable<AppUser> query = _table;
            return _appUserRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        public AppUser GetDefault(Expression<Func<AppUser, bool>> expression)
        {
            return _appUserRepository.GetDefault(expression);
        }

        public List<AppUser> GetDefaults(Expression<Func<AppUser, bool>> expression)
        {
            return _appUserRepository.GetDefaults(expression);
        }

        [ValidationAspect(typeof(AppUserValidator))]

        public void Update(AppUser entity)
        {
            _appUserRepository.Update(entity);
        }
    }
}
