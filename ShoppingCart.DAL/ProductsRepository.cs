using ShoppingCart.DAL.EntityModels;
using ShoppingCart.DAL.Interfaces;
using System;

namespace ShoppingCart.DAL
{
    public class ProductsRepository : RepositoryBase<ProductEntity>, IProductsRepository
    {
        public ProductsRepository()
        {
        }
    }
}
