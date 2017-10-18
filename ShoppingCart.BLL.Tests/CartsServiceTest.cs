using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class CartsServiceTest
    {
        private const string CART_NAME_EXISTS = "cartname_exists";
        private const string CART_NAME_NOT_EXISTS = "cartname_not_exists";
        private const int PRODUCT_ID_EXISTS = 1001;
        private const int PRODUCT_ID_NOT_EXISTS = 1011;

        private ICartsService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new CartsService();
        }

        [TestMethod]
        public void GetCartsItemsExists()
        {
            var result = service.GetCartsItems(CART_NAME_EXISTS);

            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void GetCartsItemsNotExists()
        {
            var result = service.GetCartsItems(CART_NAME_NOT_EXISTS);

            Assert.IsTrue(result.Items.Count == 0);
        }

        [TestMethod]
        public void AddToExistingCart()
        {
            var result = service.AddToCart(CART_NAME_EXISTS, PRODUCT_ID_EXISTS, 2);

            Assert.IsTrue(result.ErrorCode == 0);
        }        

        [TestCleanup]
        public void CleanupRessources()
        {
            //TODO:
        }
    }
}
