using ShoppingCart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BLL
{
    public sealed class StoreDBSingleton
    {
        private StoreDBSingleton()
        {
        }

        private static StoreDBSingleton instance = null;

        public static StoreDBSingleton Instance => instance ?? (instance = new StoreDBSingleton());

        public List<ProductItemModel> ProductItems
        {
            get
            {
                var result = new List<ProductItemModel>
                {
                    new ProductItemModel(1001, "Nintendo Switch", "Game Console", 279.99, 10),
                    new ProductItemModel(1002, "Legend Of Zelda", "Video Game", 49.99, 20),
                    new ProductItemModel(1003, "IPhone 7", "Mobile Phone", 799.99, 1),
                    new ProductItemModel(1004, "Geforce GTX", "GPU Card", 210.99, 5),
                };

                return result;
            }
        }

        private List<CartItemsModel> cartItems = new List<CartItemsModel>();

        public List<CartItemsModel> CartItems
        {
            get
            {
                var cart = new CartItemsModel("cartname_exists");
                cart.Items.Add(new CartItemModel(1001, "Nintendo Switch", 279.99, 1));
                cart.Items.Add(new CartItemModel(1004, "Geforce GTX", 210.99, 2));

                cartItems.Add(cart);

                return cartItems;
            }
            private set
            {
                cartItems = value;
            }
        }
    }
}
