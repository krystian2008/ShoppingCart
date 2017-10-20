using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;
using System.Linq;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class ProductsServiceTest
    {
        private const int PRODUCT_ID_EXISTS = 1001;
        private const int PRODUCT_ID_NOT_EXISTS = 1011;
        private const int ERROR_CODE_OK = 200;

        private IProductsService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ProductsService();
        }

        [TestMethod]
        public void ThereAreExacly4Product()
        {
            var result = _service.GetProducts();
            var expected = 4;

            Assert.AreEqual(expected, result.Items.Count);
        }

        [TestMethod]
        public void GetProducts_AreAllAvailable()
        {
            var result = _service.GetProducts();

            Assert.IsTrue(result.Items.All(x => x.Stock > 0));
        }

        [TestMethod]
        public void GetProduct_WithExistingId()
        {
            var expected = PRODUCT_ID_EXISTS;
            var result = _service.GetProducts(expected);

            Assert.AreEqual(ERROR_CODE_OK, result.ErrorCode);
        }

        [TestMethod]
        public void GetProduct_WithNotExistingId()
        {
            var result = _service.GetProducts(PRODUCT_ID_NOT_EXISTS);

            Assert.AreNotEqual(ERROR_CODE_OK, result.ErrorCode);
        }

        [TestCleanup]
        public void CleanupRessources()
        {

        }
    }
}
