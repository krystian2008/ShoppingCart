using ShoppingCart.BLL.Models;
using ShoppingCart.DAL.EntityModels;

namespace ShoppingCart.BLL.Interfaces
{
    /// <summary>
    /// Interface for classes resposible for operations on products <see cref="Product"/>
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Get all products or by id (0 = means return all)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultWrapper<ProductItemModel> GetProducts(int id = 0);
    }
}
