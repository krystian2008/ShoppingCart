using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;
using System.Linq;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class CartsServiceTest
    {
        private const string CART_NAME_EXISTS = "cartname_exists";
        private const string CART_NAME_NOT_EXISTS = "cartname_not_exists";
        private const int PRODUCT_ID_EXISTS = 1001;
        private const int PRODUCT_ID_NOT_EXISTS = 1011;

        private ICartsService _cartService;
        private IProductsService _prodService;

        [TestInitialize]
        public void Initialize()
        {
            _cartService = new CartsService();
            _prodService = new ProductsService();
        }

        [TestMethod]
        public void GetCartsItemsExists()
        {
            var result = _cartService.GetCartsItems(CART_NAME_EXISTS);

            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void GetCartsItemsNotExists()
        {
            var result = _cartService.GetCartsItems(CART_NAME_NOT_EXISTS);

            Assert.IsTrue(result.Items.Count == 0);
        }

        [TestMethod]
        public void AddToExistingCart()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 2);

            Assert.IsTrue(result.ErrorCode == 200);
        }

        [TestMethod]
        public void CheckoutExistingCart()
        {
            var result = _cartService.CheckoutCart(CART_NAME_EXISTS);

            Assert.IsTrue(result.ErrorCode == 200);
        }

        [TestMethod]
        public void CheckoutCart_DecraseStockProduct_True()
        {            
            var cart = _cartService.GetCartsItems(CART_NAME_EXISTS);
            var firstItem = cart.Items.FirstOrDefault();
            var firstItemQuantity = firstItem.Quantity;

            var productBC = _prodService.GetProducts(firstItem.ProductId);
            var productStockBC = productBC.Items.FirstOrDefault().Stock;

            _cartService.CheckoutCart(CART_NAME_EXISTS);

            var productAC = _prodService.GetProducts(firstItem.ProductId);
            var productStockAC = productAC.Items.FirstOrDefault().Stock;

            Assert.IsTrue(productStockAC == (productStockBC - firstItemQuantity));
        }

        [TestCleanup]
        public void CleanupRessources()
        {
            //TODO:
        }
    }
}
