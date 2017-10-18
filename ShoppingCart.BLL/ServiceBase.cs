using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingCart.BLL
{
    public abstract class ServiceBase<T> : IService<T>
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
