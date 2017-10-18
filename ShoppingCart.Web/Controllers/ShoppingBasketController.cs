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
    public class ShoppingBasketController : ApiController
    {
        private readonly ICartsService _service;

        public ShoppingBasketController()
        {
            _service = new CartsService();
        }

        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}")]
        public IHttpActionResult Get(string cartname)
        {
            var result = _service.GetCartsItems(cartname);

            if (result != null && result.Items != null && result.Items.Count > 0)
            {
                return Ok(result.Items);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("api/ShoppingBasket/{cartname}")]
        public IHttpActionResult Put(string cartname, [FromBody]Parameters parameters)
        {
            var result = _service.AddToCart(cartname, parameters.ProductId, parameters.Quantity);

            return Content((HttpStatusCode)result.ErrorCode, result.ErrorMessage);
        }

        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}/Checkout")]
        public IHttpActionResult Post(string cartname)
        {
            var result = _service.CheckoutCart(cartname);

            return Content((HttpStatusCode)result.ErrorCode, result.ErrorMessage);
        }
    }
}
