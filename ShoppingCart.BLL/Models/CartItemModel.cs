﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Models
{
    /// <summary>
    /// Model class for shopping cart items
    /// </summary>
    public class CartItemModel
    {
        public CartItemModel()
        {
        }

        public CartItemModel(int productId, string productName, decimal unitPrice, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
