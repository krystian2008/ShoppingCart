using ShoppingCart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Interfaces
{
    public interface IProductService : IService<ProductItemModel>
    {
        ResultWrapper<ProductItemModel> GetProducts();
    }
}
