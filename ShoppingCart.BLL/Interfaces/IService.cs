using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Interfaces
{
    public interface IService<T>
    {       
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IList<T> GetAll();
        long Count();        
    }
}
