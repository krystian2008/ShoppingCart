using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class ProductsServiceTest
    {
        private IProductService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new ProductsService();
        }

        [TestMethod]
        public void GetProducts()
        {
            var result = service.GetProducts();

            Assert.IsTrue(result.ErrorCode == 0);
        }

        [TestCleanup]
        public void CleanupRessources()
        {
            //TODO:
        }
    }
}
