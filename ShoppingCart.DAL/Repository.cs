using ShoppingCart.DAL.Infrastructure;
using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IContext<T> _context;

        public Repository()
        {
            _context = new Context<T>();
        }

        public Repository(IContext<T> context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.DbSet.Add(entity);
        }

        public int Count()
        {
            return _context.DbSet.Count();
        }

        public T Delete(T entity)
        {
            return _context.DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.DbSet;
        }

        public void SaveChanges()
        {
            _context.DbCtx.SaveChanges();
        }

        public T Update(T entity)
        {
            var updated = _context.DbSet.Attach(entity);
            _context.DbCtx.Entry(entity).State = EntityState.Modified;
            return updated;
        }
    }
}
