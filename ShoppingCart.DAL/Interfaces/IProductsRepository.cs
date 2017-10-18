using ShoppingCart.DAL.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL.Interfaces
{
    public interface IProductsRepository : IRepository<ProductEntity>
    {
    }
}
