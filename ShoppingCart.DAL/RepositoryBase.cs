using ShoppingCart.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        public void AddProductToShoppingCart(string cartname, int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void CheckoutShoppingCart(string cartname)
        {
            throw new NotImplementedException();
        }

        public T GetShoppingCart(string cartname)
        {
            throw new NotImplementedException();
        }
    }
}
