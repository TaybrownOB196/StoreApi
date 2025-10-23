using StoreApi.Data;
using StoreApi.Data.Models;

namespace StoreApi.Infra 
{
    public class ShoppingCartModelOperator : IShoppingCartModelOperator
    {
        private readonly IReadObjects<ShoppingCart> _reader;
        private readonly IWriteObjects<ShoppingCart> _writer;

        public ShoppingCartModelOperator(
            IReadObjects<ShoppingCart> reader,
            IWriteObjects<ShoppingCart> writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            return await _reader.RetrieveObject();
        }

        public async Task SaveShoppingCart(ShoppingCart shoppingCart) 
        {
            await _writer.WriteObject(shoppingCart);
        }
    }
}