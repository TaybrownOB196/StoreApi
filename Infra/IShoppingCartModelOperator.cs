using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra
{
    public interface IShoppingCartFileModelReader
    {
        Task<ShoppingCart> GetShoppingCart();
    }
}