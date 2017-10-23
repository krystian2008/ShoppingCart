using ShoppingCart.BLL.Models;
using ShoppingCart.DAL.EntityModels;

namespace ShoppingCart.BLL.Interfaces
{
    /// <summary>
    /// Interface for classes resposible for operations on <see cref="CartItem"/>
    /// </summary>
    public interface ICartsService
    {
        /// <summary>
        /// Get shopping cart items by cartname
        /// </summary>
        /// <param name="cartname"></param>
        /// <returns></returns>
        ResultWrapper<CartItemModel> GetCartsItems(string cartname);
        /// <summary>
        /// Add product with the chosen quantity to the shopping cart
        /// </summary>
        /// <param name="cartname"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        ResultWrapper<CartItemModel> AddToCart(string cartname, int productId, int quantity);
        /// <summary>
        /// Checkout shopping cart by cartname
        /// </summary>
        /// <param name="cartname"></param>
        /// <returns></returns>
        ResultWrapper<CartItemModel> CheckoutCart(string cartname);
    }
}
