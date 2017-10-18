using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL.Models
{
    public class ProductItemModel : IProductItem
    {
        private int id;
        private string name;
        private string description;
        private double price;
        private int stock;

        public ProductItemModel(int id, string name, string description, double price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
