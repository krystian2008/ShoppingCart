using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Web.Controllers;

namespace ShoppingCart.Web.Tests
{
    [TestClass]
    public class ShoppingBasketControllerTest
    {
        private const string CART_NAME_EXISTS = "cartname_exists";

        [TestMethod]
        public void GetCart()
        {
            var controller = new ShoppingBasketController();
            var result = controller.Get(CART_NAME_EXISTS);

            Assert.IsNotNull(result);
        }
    }
}
