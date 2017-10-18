using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Models
{
    public class ProductItemsModel : IProductItem
    {
        public ProductItemsModel()
        {
            ProductItemsList = new List<ProductItemModel>();
        }

        public List<ProductItemModel> ProductItemsList { get; set; }
    }
}
