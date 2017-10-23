using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Web.Models
{
    /// <summary>
    /// Class Parameters to use in Shopping Basket Controller
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Quantity of product
        /// </summary>
        public int Quantity { get; set; }
    }
}