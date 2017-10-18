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
            var product = StoreDBSingleton.Instance.ProductItems.FirstOrDefault(x => x.Id == productId);

            if (cart == null)
            {
                result.ErrorCode = 404;
                result.ErrorMessage = "shopping cart does not exist";

                return result;
            }
            
            if (product == null)
            {
                result.ErrorCode = 404;
                result.ErrorMessage = "product does not exist";

                return result;
            }

            if (cart != null && product != null)
            {
                //enought quantity
                if (product.Stock >= quantity)
                {
                    //check if product has already exists in cart
                    int index = cart.Items.FindIndex(x => x.ProductId == productId);
                    if (index >= 0)
                    {
                        cart.Items[index].Quantity += quantity;
                    }
                    else
                    {
                        cart.Items.Add(new CartItemModel(product.Id, product.Name, product.Price, quantity));
                    }                    
                }
                else
                {
                    result.ErrorCode = 400;
                    result.ErrorMessage = "not enough quantity";

                    return result;
                }
            }

            return result;
        }

        public ResultWrapper<CartItemModel> CheckoutCart(string cartname)
        {
            throw new NotImplementedException();
        }

        public void Delete(CartItemModel entity)
        {
            throw new NotImplementedException();
        }

        public ResultWrapper<CartItemModel> GetCartsItems(string cartname)
        {
            var cart = StoreDBSingleton.Instance.CartItems.FirstOrDefault(x => string.Compare(x.CartName, cartname, true) == 0);
            var result = new ResultWrapper<CartItemModel>();

            if (cart != null)
            {
                result.Items = cart.Items;
            }
            else
            {
                result.ErrorCode = 404;
                result.ErrorMessage = "cart does not exist";
            }

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
