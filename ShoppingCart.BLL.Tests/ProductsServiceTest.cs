using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class ProductsServiceTest
    {
        private IProductsService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ProductsService();
        }

        [TestMethod]
        public void GetProducts()
        {
            var result = _service.GetProducts();

            Assert.IsTrue(result.ErrorCode == 200);
        }

        [TestCleanup]
        public void CleanupRessources()
        {
            //TODO:
        }
    }
}
