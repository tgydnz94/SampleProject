using Microsoft.EntityFrameworkCore;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfLikeRepository : ILikeRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Like> _table;
        public EfLikeRepository(ProjectContext context)
        {
            _context = context;
            _table = _context.Set<Like>();
        }



        public void Create(Like entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Like entity)
        {
            // baseEntityden kalıtım almadığından statu/updateDate vb. propları yoktur bu yüzden doğrudan veritabanından sildik.
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public Like GetDefault(Expression<Func<Like, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }
    }
}
