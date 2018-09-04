using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreApi.Infra
{
    public interface IReadObjects<T> where T : new()
    {
        Task<T> RetrieveObject();
    }
}