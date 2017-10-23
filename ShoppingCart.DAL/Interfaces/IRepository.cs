using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Interfaces
{
    /// <summary>
    /// Interface for repostory classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        IQueryable<T> GetAll();
        int Count();
        void SaveChanges();
    }
}
