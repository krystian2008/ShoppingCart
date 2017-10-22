using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;
using System.Linq;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class CartsServiceTest
    {
        private const string CART_NAME_EXISTS = "cartname_01";
        private const string CART_NAME_NOT_EXISTS = "cartname_03";
        private const int PRODUCT_ID_EXISTS = 1001;
        private const int PRODUCT_ID_NOT_EXISTS = 1011;
        private const int PRODUCT_QUANTITY = 1;
        private const int ERROR_CODE_OK = 200;

        private ICartsService _cartService;
        private IProductsService _prodService;

        [TestInitialize]
        public void Initialize()
        {
            _cartService = new CartsService();
            _prodService = new ProductsService();
        }

        [TestMethod]
        public void GetCart_WithExistingName_StatusCode200()
        {
            var result = _cartService.GetCartsItems(CART_NAME_EXISTS);

            Assert.AreEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void GetCart_WithNotExistingName()
        {
            var result = _cartService.GetCartsItems(CART_NAME_NOT_EXISTS);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToExistingCart()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);

            Assert.AreEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToNotExistingCart()
        {
            var result = _cartService.AddToCart(CART_NAME_NOT_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_NotExistingProduct_ToExistingCart_ExpectedCode404_ShoppingCartDoesNotExistMessageExpected() //   AddNotExistingProduct_ToExistingCart()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_NOT_EXISTS, PRODUCT_QUANTITY);

            //TODO: add ERROR_CODE for each returned code 404,...
            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddNotExistingProduct_ToNotExistingCart()
        {
            var result = _cartService.AddToCart(CART_NAME_NOT_EXISTS, PRODUCT_ID_NOT_EXISTS, PRODUCT_QUANTITY);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToExistingCart_NotEnoughQuantity()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 1000);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToExistingCart_QuantityZero()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 0);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToExistingCart_QuantityNegative()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, -1000);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void CheckoutExistingCart()
        {
            var result = _cartService.CheckoutCart(CART_NAME_EXISTS);

            Assert.AreEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void CheckoutNotExistingCart()
        {
            var result = _cartService.CheckoutCart(CART_NAME_NOT_EXISTS);

            Assert.AreNotEqual(ERROR_CODE_OK, result.Code, result.Message);
        }

        [TestMethod]
        public void GetCart_WithAddedNewExistingProduct()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);
            var cart = _cartService.GetCartsItems(CART_NAME_EXISTS);

            Assert.IsNotNull(cart.Items.FirstOrDefault(x => x.ProductId == PRODUCT_ID_EXISTS));
        }

        [TestMethod]
        public void CheckoutExistingCart_DecraseStockProduct()
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
        }
    }
}
