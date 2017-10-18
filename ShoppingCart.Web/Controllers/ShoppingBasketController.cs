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
        private ICartsService service;

        public ShoppingBasketController()
        {
            service = new CartsService();
        }

        [HttpGet]
        [Route("api/ShoppingBasket/{cartname}")]
        public IHttpActionResult Get(string cartname)
        {
            var result = service.GetCartsItems(cartname);

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
            var result = service.AddToCart(cartname, parameters.ProductId, parameters.Quantity);

            switch (result.ErrorCode)
            {
                case 400:
                    return BadRequest(result.ErrorMessage);
                case 404:
                    return NotFound();
                default:
                    break;
            }

            return Ok(result.ErrorMessage);
        }

        // POST: api/ShoppingBasket
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShoppingBasket/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE: api/ShoppingBasket/5
        public void Delete(int id)
        {
        }
    }
}
