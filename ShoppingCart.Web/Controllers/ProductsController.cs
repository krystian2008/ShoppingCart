using ShoppingCart.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    public class ProductsController : Controller
    {
        /// <summary>
        /// List of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add product to cart (future use)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult AddToCart(int productId)
        {
            return RedirectToAction("Index");
        }
    }
}