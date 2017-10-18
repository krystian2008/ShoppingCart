using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.DAL.EntityModels
{
    public class CartEntity
    {
        private int productId;
        private string productName;
        private double unitPrice;
        private int quantity;

        public CartEntity(int productId, string productName, double unitPrice, int quantity)
        {
            this.productId = productId;
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
