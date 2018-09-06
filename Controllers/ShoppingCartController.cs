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
        private readonly IShoppingCartModelOperator _cartOperator;
        public ShoppingCartController(IShoppingCartModelOperator cartOperator) => _cartOperator = cartOperator;

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> Get() 
        {
            return await _cartOperator.GetShoppingCart();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Item item) 
        {
            _cartOperator.SaveShoppingCart().ConfigureAwait(false);

            return new OkResult();
        }

        [HttpPut]
        public ActionResult Put([FromBody]Item item) 
        {
            _cartOperator.AddItemToCart(item).ConfigureAwait(false);

            return new OkResult();
        }
    }
}
