using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
using System.Linq;

namespace ShoppingCart.BLL.Tests
{
    [TestClass]
    public class ProductsServiceTest
    {
        private const int PRODUCT_ID_EXISTS = 1001;
        private const int PRODUCT_ID_NOT_EXISTS = 1011;
        private const int CODE_200 = 200;

        private IProductsService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new ProductsService();
        }

        [TestMethod]
        public void GetProducts_InitialStoreState_ExaclyFourProductExpected()
        {
            var result = _service.GetProducts();
            var expected = 4;

            Assert.AreEqual(CODE_200, result.Code);
            Assert.IsNotNull(result.Items);
            Assert.AreEqual(expected, result.Items.Count);
        }

        [TestMethod]
        public void GetProducts_InitialStoreState_AllProductsAreInStock()
        {
            var result = _service.GetProducts();
            AssertBasicResult(result);
            Assert.IsTrue(result.Items.All(x => x.Stock > 0));
        }

        private static void AssertBasicResult(ResultWrapper<ProductItemModel> result, int code = 0)
        {
            Assert.AreEqual(CODE_200, result.Code);
            Assert.IsNotNull(result.Items);
        }

        [TestMethod]
        public void GetProduct_ByExistingId_ProductExpected()
        {
            var result = _service.GetProducts(PRODUCT_ID_EXISTS);
            
            Assert.AreEqual(CODE_200, result.Code);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count == 1, "Collection must contain exacly one item");
            Assert.AreEqual(PRODUCT_ID_EXISTS, result.Items[0].Id);
        }

        [TestMethod]
        public void GetProduct_ByNotExistingId_NoneProductExpected()
        {
            var result = _service.GetProducts(PRODUCT_ID_NOT_EXISTS);

            Assert.AreNotEqual(CODE_200, result.Code);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count == 0, "Collection must be empty");
        }
    }
}
