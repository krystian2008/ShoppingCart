using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL.EntityModels
{
    public class CartEntity
    {       
        public CartEntity(int productId, string productName, double unitPrice, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
