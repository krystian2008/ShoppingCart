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
            initProducts();
            initCart();
        }

        private static StoreDBSingleton instance = null;

        public static StoreDBSingleton Instance => instance ?? (instance = new StoreDBSingleton());

        private List<ProductItemModel> _productItems = new List<ProductItemModel>();

        public List<ProductItemModel> ProductItems
        {
            get
            {
                return _productItems;
            }
        }

        private List<CartItemsModel> _cartItems = new List<CartItemsModel>();

        public List<CartItemsModel> CartItems
        {
            get
            {
                return _cartItems;
            }
            private set
            {
                _cartItems = value;
            }
        }

        private void initProducts()
        {
            _productItems.Add(new ProductItemModel(1001, "Nintendo Switch", "Game Console", 279.99, 10));
            _productItems.Add(new ProductItemModel(1002, "Legend Of Zelda", "Video Game", 49.99, 20));
            _productItems.Add(new ProductItemModel(1003, "IPhone 7", "Mobile Phone", 799.99, 1));
            _productItems.Add(new ProductItemModel(1004, "Geforce GTX", "GPU Card", 210.99, 5));
        }

        private void initCart()
        {
            var cart = new CartItemsModel("cartname_01");
            cart.Items.Add(new CartItemModel(1001, "Nintendo Switch", 279.99, 1));
            cart.Items.Add(new CartItemModel(1004, "Geforce GTX", 210.99, 2));

            _cartItems.Add(cart);
        }
    }
}
