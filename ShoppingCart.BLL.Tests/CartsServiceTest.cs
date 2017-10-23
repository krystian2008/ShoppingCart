using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Mappings;
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
        private const int CODE_200 = 200;
        private const int CODE_400 = 400;
        private const int CODE_404 = 404;

        private ICartsService _cartService;
        private IProductsService _prodService;

        [TestInitialize]
        public void Initialize()
        {
            _cartService = new CartsService();
            _prodService = new ProductsService();
            ObjectMapper.ConfigureAutoMapper();
        }

        [TestMethod]
        public void GetCart_WithExistingName_ExpectedCode200()
        {
            var result = _cartService.GetCartsItems(CART_NAME_EXISTS);

            Assert.AreEqual(CODE_200, result.Code, result.Message);
        }

        [TestMethod]
        public void GetCart_WithNotExistingName_ExpectedCode404()
        {
            var result = _cartService.GetCartsItems(CART_NAME_NOT_EXISTS);

            Assert.AreEqual(CODE_404, result.Code, result.Message);
        }

        [TestMethod]
        public void GetCart_AddExistingProductToExistingCart_ExpectedAddedProductInCartItems()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);
            var cart = _cartService.GetCartsItems(CART_NAME_EXISTS);

            Assert.IsNotNull(cart.Items.FirstOrDefault(x => x.ProductId == PRODUCT_ID_EXISTS));
        }

        [TestMethod]
        public void AddToCart_ExistingProductToExistingCart_ExpectedCode200()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);

            Assert.AreEqual(CODE_200, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_ExistingProductToNotExistingCart_ExpectedCode404()
        {
            var result = _cartService.AddToCart(CART_NAME_NOT_EXISTS, PRODUCT_ID_EXISTS, PRODUCT_QUANTITY);

            Assert.AreEqual(CODE_404, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_NotExistingProduct_ToExistingCart_ExpectedCode404_ShoppingCartDoesNotExistMessageExpected()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_NOT_EXISTS, PRODUCT_QUANTITY);

            Assert.AreEqual(CODE_404, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_NotExistingProductToNotExistingCart_ExpectedCode404()
        {
            var result = _cartService.AddToCart(CART_NAME_NOT_EXISTS, PRODUCT_ID_NOT_EXISTS, PRODUCT_QUANTITY);

            Assert.AreEqual(CODE_404, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_ExistingProductToExistingCart_InsufficientQuantity_ExpectedCode400()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 1000);

            Assert.AreEqual(CODE_400, result.Code, result.Message);
        }

        [TestMethod]
        public void AddToCart_ExistingProductToExistingCart_ZeroQuantity_ExpectedCode400()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 0);

            Assert.AreEqual(CODE_400, result.Code, result.Message);
        }

        [TestMethod]
        public void AddExistingProduct_ToExistingCart_NegativeQuantity_ExpectedCode400()
        {
            var result = _cartService.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, -1000);

            Assert.AreEqual(CODE_400, result.Code, result.Message);
        }

        [TestMethod]
        public void CheckoutCart_ExistingCart_ExpectedCode200()
        {
            var result = _cartService.CheckoutCart(CART_NAME_EXISTS);

            Assert.AreEqual(CODE_200, result.Code, result.Message);
        }

        [TestMethod]
        public void CheckoutCart_NotExistingCart_ExpectedCode404()
        {
            var result = _cartService.CheckoutCart(CART_NAME_NOT_EXISTS);

            Assert.AreEqual(CODE_404, result.Code, result.Message);
        }       

        [TestMethod]
        public void CheckoutCart_DecraseProductAfterCheckoutCart_ExpectedReducedQuantityOfProduc()
        {            
            var cart = _cartService.GetCartsItems(CART_NAME_EXISTS);
            var firstItem = cart.Items.FirstOrDefault();
            var firstItemQuantity = firstItem.Quantity;

            var productBC = _prodService.GetProducts(firstItem.ProductId);
            var productStockBC = productBC.Items.FirstOrDefault().Stock;

            _cartService.CheckoutCart(CART_NAME_EXISTS);

            _prodService = new ProductsService();
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
