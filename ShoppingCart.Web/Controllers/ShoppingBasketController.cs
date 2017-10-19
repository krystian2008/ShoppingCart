using ShoppingCart.BLL;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    /// <summary>
    /// Shopping Basket Api Controller
    /// </summary>
    public class ShoppingBasketController : ApiController
    {
        private readonly ICartsService _service = null;

        /// <summary>
        /// CTOR
        /// </summary>
        public ShoppingBasketController(ICartsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get the shopping cart details
        /// </summary>
        /// <param name="cartname"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}")]
        public IHttpActionResult Get(string cartname)
        {
            var result = _service.GetCartsItems(cartname);

            if (result != null && result.Items != null && result.Items.Count > 0)
            {
                return Ok(result.Items);
            }

            return Content((HttpStatusCode)result.ErrorCode, result.ErrorMessage);
        }

        /// <summary>
        /// Add a product to the shopping cart
        /// </summary>
        /// <param name="cartname"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/ShoppingBasket/{cartname}")]
        public IHttpActionResult Put(string cartname, [FromBody]ProductInfo parameters)
        {
            var result = _service.AddToCart(cartname, parameters.ProductId, parameters.Quantity);

            return Content((HttpStatusCode)result.ErrorCode, result.ErrorMessage);
        }

        /// <summary>
        /// Checkout shopping cart
        /// </summary>
        /// <param name="cartname"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}/Checkout")]
        public IHttpActionResult Post(string cartname)
        {
            var result = _service.CheckoutCart(cartname);

            return Content((HttpStatusCode)result.ErrorCode, result.ErrorMessage);
        }
    }
}
