using System;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra 
{
    public class ShoppingCartModelOperator : IShoppingCartModelOperator
    {
        private static ShoppingCart _shoppingCart;
        
        public ShoppingCartModelOperator() { }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            if (_shoppingCart is null)
            {
                _shoppingCart = await new ShoppingCartModelReader().RetrieveObject();
            }

            return _shoppingCart;
        }

        public Task SaveShoppingCart() 
        {
            if (_shoppingCart is null) 
            {
                throw new InvalidOperationException("Shopping cart in invalid state");
            }

            new ShoppingCartModelWriter().WriteObject(_shoppingCart).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public Task AddItemToCart(Item item) 
        {
            if (_shoppingCart is null) 
            {
                throw new InvalidOperationException("Shopping cart in invalid state");
            }

            if (item == null)
            {
                throw new ArgumentNullException("Item in invalid state, unable to add to cart");
            }

            _shoppingCart.Items.Add(item);

            return Task.CompletedTask;
        }
    }

    class ShoppingCartModelReader : DataFileModelReader<ShoppingCart>
    {
        public ShoppingCartModelReader() 
            : base("data.json", false) { }
    }

    class ShoppingCartModelWriter : DataFileModelWriter<ShoppingCart>
    {
        public ShoppingCartModelWriter() 
            : base("data.json") { }
    }
}