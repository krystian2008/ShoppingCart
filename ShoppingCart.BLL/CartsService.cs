using ShoppingCart.BLL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL.Interfaces;
using ShoppingCart.DAL;

namespace ShoppingCart.BLL
{
    public class CartsService : ServiceBase<ICartsService>, ICartsService
    {
        private ICartsRepository _cartsRepository;
        private IProductsRepository _productsRepository;

        public CartsService()
           : this(new CartsRepository(), new ProductsRepository())
        {
        }

        public CartsService(ICartsRepository cartsRepository, IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository ?? new CartsRepository();
            _productsRepository = productsRepository ?? new ProductsRepository();
        }

        public void Add(CartItemModel entity)
        {
            throw new NotImplementedException();
        }

        public ResultWrapper<CartItemModel> AddToCart(string cartname, int productId, int quantity)
        {
            var result = new ResultWrapper<CartItemModel>();
            var cart = StoreDBSingleton.Instance.CartItems.FirstOrDefault(x => string.Compare(x.CartName, cartname, true) == 0);

            if (cart == null)
            {
                result.SetErrorMessage("shopping cart does not exist", 404);

                return result;
            }

            var product = StoreDBSingleton.Instance.ProductItems.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                result.SetErrorMessage("product does not exist", 404);

                return result;
            }

            if (product.Stock < quantity)
            {
                result.SetErrorMessage("not enough quantity", 400);

                return result;
            }

            int index = cart.Items.FindIndex(x => x.ProductId == productId);
            if (index >= 0)
            {
                cart.Items[index].Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItemModel(product.Id, product.Name, product.Price, quantity));
            }

            return result;
        }

        public ResultWrapper<CartItemModel> CheckoutCart(string cartname)
        {
            var result = new ResultWrapper<CartItemModel>();
            var cart = StoreDBSingleton.Instance.CartItems.FirstOrDefault(x => string.Compare(x.CartName, cartname, true) == 0);
            var prodExists = StoreDBSingleton.Instance.ProductItems.Any();

            if (cart == null || !prodExists)
            {
                result.SetErrorMessage("shopping cart does not exist or products in the shopping cart do not exist", 404);

                return result;
            }

            foreach (var item in cart.Items)
            {
                var product = StoreDBSingleton.Instance.ProductItems.FirstOrDefault(x => x.Id == item.ProductId);

                if (product == null || (product != null && product.Stock < item.Quantity))
                {
                    result.SetErrorMessage("not enough quantity, other stock related issues", 400);

                    return result;
                }

                product.Stock -= item.Quantity;
            }

            result.SetErrorMessage("successfully checked out shopping cart");

            return result;
        }

        public void Delete(CartItemModel entity)
        {
            throw new NotImplementedException();
        }

        public ResultWrapper<CartItemModel> GetCartsItems(string cartname)
        {
            var result = new ResultWrapper<CartItemModel>();
            var cart = StoreDBSingleton.Instance.CartItems.FirstOrDefault(x => string.Compare(x.CartName, cartname, true) == 0);

            if (cart == null)
            {
                result.SetErrorMessage("cart does not exist", 404);
            }

            result.Items = cart.Items;

            return result;
        }

        public void Update(CartItemModel entity)
        {
            throw new NotImplementedException();
        }

        IList<CartItemModel> IService<CartItemModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
