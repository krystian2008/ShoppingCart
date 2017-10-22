using ShoppingCart.BLL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Models
{
    public class CartItemsModel : ICartItem
    {
        public readonly string CartName;

        public CartItemsModel(string cartname)
        {
            this.CartName = cartname;;
        }

        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();

        public double TotalPrice
        {
            get { return Items.Sum(x => x.Quantity * x.UnitPrice); }
        }
    }
}
