using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [Route(nameof(Get))]
        public async Task<ActionResult<ShoppingCart>> Get() 
        {
            return await _cartOperator.GetShoppingCart();
        }

        [HttpPost]
        [Route(nameof(Save))]
        public async Task<ActionResult> Save(ShoppingCart shoppingCart) 
        {
            await _cartOperator.SaveShoppingCart(shoppingCart);

            return new OkResult();
        }
    }
}
