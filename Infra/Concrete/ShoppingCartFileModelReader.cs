using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Infra 
{
    public class ShoppingCartFileModelReader : DataFileModelReader<ShoppingCart>, IShoppingCartFileModelReader
    {
        public ShoppingCartFileModelReader() 
            : base("data.json", true) { }

        public Task<ShoppingCart> GetShoppingCart()
        {
            return RetrieveObject();
        }
    }
}