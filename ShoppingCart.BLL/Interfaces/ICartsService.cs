using ShoppingCart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Interfaces
{
    public interface ICartsService : IService<CartItemModel>
    {
        ResultWrapper<CartItemModel> GetCartsItems(string cartname);
        ResultWrapper<CartItemModel> AddToCart(string cartname, int productId, int quantity);
        ResultWrapper<CartItemModel> CheckoutCart(string cartname);
    }
}
