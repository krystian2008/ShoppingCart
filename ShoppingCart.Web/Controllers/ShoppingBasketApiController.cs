using log4net;
using ShoppingCart.BLL;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
using ShoppingCart.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    /// <summary>
    /// Shopping Basket Api Controller
    /// </summary>
    public class ShoppingBasketApiController : ApiController
    {
        private readonly ICartsService _service;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// CTOR
        /// </summary>
        public ShoppingBasketApiController(ICartsService service)
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
            try
            {
                var result = _service.GetCartsItems(cartname);

                if (result != null && result.Items != null && result.Items.Count > 0)
                {
                    return Ok(result.Items);
                }

                return Content((HttpStatusCode)result.Code, result.Message);
            }
            catch (Exception ex)
            {
                return HandleException($"Exception - GetCartsItems, parameters: cartname='{cartname}'", ex);
            }
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
            try
            {
                var result = _service.AddToCart(cartname, parameters.ProductId, parameters.Quantity);

                return Content((HttpStatusCode)result.Code, result.Message);
            }
            catch (Exception ex)
            {
                return HandleException($"Exception - AddToCart, parameters: cartname='{cartname}', ProductId='{parameters?.ProductId}', Quantity='{parameters?.Quantity}'", ex);
            }
        }

        /// <summary>
        /// Checkout shopping cart
        /// </summary>
        /// <param name="cartname"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}/Checkout")]
        public IHttpActionResult Checkout(string cartname)
        {
            try
            {
                var result = _service.CheckoutCart(cartname);

                return Content((HttpStatusCode)result.Code, result.Message);
            }
            catch (Exception ex)
            {
                return HandleException($"Exception - CheckoutCart, parameters: cartname='{cartname}'", ex);
            }
        }

        private IHttpActionResult HandleException(string msg ,Exception ex)
        {            
            log.Error(msg, ex);

            return InternalServerError();
        }
    }
}
