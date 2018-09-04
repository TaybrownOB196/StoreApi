using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApi.Infra;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartModelOperator _cartReader;
        public ShoppingCartController(IShoppingCartModelOperator reader) => _cartReader = reader;

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> Get() 
        {
            return await _cartReader.GetShoppingCart();
        }

        [HttpPut]
        public ActionResult Put([FromBody]Item item) 
        {
            var shoppingCart = _cartReader.GetShoppingCart();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            shoppingCart.Items.Add(item);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromBody]Item item) 
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            shoppingCart.Items.Remove(item);

            return new OkResult();
        }
    }
}
