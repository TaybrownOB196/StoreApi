using System.Threading.Tasks;

namespace StoreApi.Data
{
    public interface IReadObjects<T> where T : new()
    {
        Task<T> RetrieveObject();
    }
}