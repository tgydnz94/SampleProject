using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Core.Entity.Abstract;
using SampleProject.Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleProject.Core.DataAccess.Concrete
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
                                       where TEntity : BaseEntity
                                       where TContext : IdentityDbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _table;

        public EfBaseRepository(TContext context)
        {
            _context = context;
            _table=_context.Set<TEntity>();
        }
        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Any(expression);
        }

        public void Create(TEntity entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Statu = Statu.InActive;
            _context.SaveChanges();
        }

        public TResult GetByDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _table;
            if (include != null) query = include(query);
            return query.Where(expression).Select(selector).FirstOrDefault();
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _table;

            if (include != null) query = include(query);

            if (orderBy != null) return orderBy(query).Where(expression).Select(selector).ToList();

            return query.Where(expression).Select(selector).ToList();
        }

        public TEntity GetDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<TEntity> GetDefaults(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public void Update(TEntity entity)
        {
            entity.Statu = Statu.Modified;
            entity.UpdatedDate = DateTime.Now;
            _table.Update(entity);
            _context.SaveChanges();
        }
    }
}
