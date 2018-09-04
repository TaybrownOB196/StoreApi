using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra 
{
    public class ShoppingCartModelOperator : DataFileModelReader<ShoppingCart>, IShoppingCartModelOperator
    {
        private static ShoppingCart _shoppingCart;
        public ShoppingCartModelOperator() 
            : base("data.json", true) { }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            if (_shoppingCart is null)
                _shoppingCart = await RetrieveObject();
            return _shoppingCart;
        }
    }
}