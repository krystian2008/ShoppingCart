using log4net;
using ShoppingCart.BLL;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.Models;
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
    public class ShoppingBasketController : ApiController
    {
        private readonly ICartsService _service;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                var msg = string.Format("Exception - GetCartsItems, parameters: cartname='{0}'", cartname);
                log.Error(msg, ex);

                return InternalServerError();
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
                var msg = string.Format("Exception - AddToCart, parameters: cartname='{0}', ProductId='{1}', Quantity='{2}'", cartname, parameters.ProductId, parameters.Quantity);
                log.Error(msg, ex);

                return InternalServerError();
            }
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
            try
            {
                var result = _service.CheckoutCart(cartname);

                return Content((HttpStatusCode)result.Code, result.Message);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Exception - CheckoutCart, parameters: cartname='{0}'", cartname);
                log.Error(msg, ex);

                return InternalServerError();
            }
        }
    }
}
