using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetShoppingCart(string cartname);
        void AddProductToShoppingCart(string cartname, int productId, int quantity);
        void CheckoutShoppingCart(string cartname);
    }
}
