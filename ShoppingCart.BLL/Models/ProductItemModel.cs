using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Models
{
    public class ProductItemModel : IProductItem
    {
        public ProductItemModel(int id, string name, string description, double price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
