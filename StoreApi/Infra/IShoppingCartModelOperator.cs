using StoreApi.Data.Models;

namespace StoreApi.Infra
{
    public interface IShoppingCartModelOperator
    {
        Task<ShoppingCart> GetShoppingCart();
        Task SaveShoppingCart(ShoppingCart shoppingCart);
    }
}