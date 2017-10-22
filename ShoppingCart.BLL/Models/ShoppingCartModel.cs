using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.Models
{
    public class ShoppingCartModel
    {
        /// <summary>
        /// Idetified
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cart name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// List of product in shopping cart
        /// </summary>
        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();

        public ShoppingCartModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
