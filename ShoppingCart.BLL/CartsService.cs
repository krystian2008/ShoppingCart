using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Mappings;
using ShoppingCart.BLL.Models;
using ShoppingCart.DAL;
using ShoppingCart.DAL.EntityModels;
using ShoppingCart.DAL.Interfaces;
using System.Linq;


namespace ShoppingCart.BLL
{
    /// <summary>
    /// Service class for Carts <see cref="CartItemModel"/>
    /// </summary>
    public class CartsService : ICartsService
    {
        private readonly IRepository<Product> _repoProd;
        private readonly IRepository<DAL.EntityModels.ShoppingCart> _repoCart;

        public CartsService()
        {
            _repoProd = new Repository<Product>();
            _repoCart = new Repository<DAL.EntityModels.ShoppingCart>();
        }

        private DAL.EntityModels.ShoppingCart getCart(string cartname)
        {
            return _repoCart.GetAll().FirstOrDefault(x => string.Compare(x.Name, cartname, true) == 0);
        }

        public ResultWrapper<CartItemModel> AddToCart(string cartname, int productId, int quantity)
        {
            var result = new ResultWrapper<CartItemModel>();
            var cart = getCart(cartname);

            if (cart == null)
            {
                result.SetErrorMessage("shopping cart does not exist", 404);

                return result;
            }

            var product = _repoProd.GetAll().FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                result.SetErrorMessage("product does not exist", 404);

                return result;
            }

            if (product.Stock < quantity || quantity <= 0)
            {
                result.SetErrorMessage("not enough quantity", 400);

                return result;
            }

            var prodInCart = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (prodInCart != null)
            {
                prodInCart.Quantity += quantity;
                _repoCart.Update(prodInCart.ShoppingCart);
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                };
                cart.CartItems.Add(newItem);
            }

            _repoCart.SaveChanges();

            result.SetErrorMessage("product successfully added");

            return result;
        }

        public ResultWrapper<CartItemModel> CheckoutCart(string cartname)
        {
            var result = new ResultWrapper<CartItemModel>();
            var cart = getCart(cartname);
            var prodExists = _repoProd.GetAll().Any();

            if (cart == null || !prodExists)
            {
                result.SetErrorMessage("shopping cart does not exist or products in the shopping cart do not exist", 404);

                return result;
            }

            foreach (var item in cart.CartItems)
            {
                var product = _repoProd.GetAll().FirstOrDefault(x => x.Id == item.ProductId);

                if (product == null || (product != null && product.Stock < item.Quantity))
                {
                    result.SetErrorMessage("not enough quantity, other stock related issues", 400);

                    return result;
                }

                product.Stock -= item.Quantity;
                _repoProd.Update(product);
            }

            _repoProd.SaveChanges();

            result.SetErrorMessage("successfully checked out shopping cart");

            return result;
        }

        public ResultWrapper<CartItemModel> GetCartsItems(string cartname)
        {
            var cart = getCart(cartname);
            var result = new ResultWrapper<CartItemModel>();

            if (cart == null)
            {
                result.SetErrorMessage("cart does not exist", 404);
                return result;
            }

            cart.CartItems.ToList().ForEach(x => result.Items.Add(ObjectMapper.MapCart(x)));

            return result;
        }
    }
}
