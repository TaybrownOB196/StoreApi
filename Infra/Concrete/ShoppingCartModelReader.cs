using System;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra 
{
    public class ShoppingCartModelOperator : IShoppingCartModelOperator
    {
        private static ShoppingCart _shoppingCart;
        private DataFileModelReader<ShoppingCart> _shoppingCartReader;
        private DataFileModelWriter<ShoppingCart> _shoppingCartWriter;
        public ShoppingCartModelOperator()
        {

        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            if (_shoppingCart is null)
                _shoppingCart = await _shoppingCartReader.RetrieveObject();
            return _shoppingCart;
        }

        public Task SaveShoppingCart() 
        {
            if (_shoppingCart is null)
                throw new InvalidOperationException("Shopping cart in invalid state");
            _shoppingCartWriter.WriteObject(_shoppingCart).ConfigureAwait(false);
            return Task.CompletedTask;
        }
    }
}