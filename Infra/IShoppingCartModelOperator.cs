using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra
{
    public interface IShoppingCartModelOperator
    {
        Task<ShoppingCart> GetShoppingCart();
        Task SaveShoppingCart();
        Task AddItemToCart(Item item);
    }
}