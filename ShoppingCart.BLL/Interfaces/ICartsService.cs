using ShoppingCart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Interfaces
{
    public interface ICartsService
    {
        ResultWrapper<CartItemModel> GetCartsItems(string cartname);
        ResultWrapper<CartItemModel> AddToCart(string cartname, int productId, int quantity);
        ResultWrapper<CartItemModel> CheckoutCart(string cartname);
    }
}
