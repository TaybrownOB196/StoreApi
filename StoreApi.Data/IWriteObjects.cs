using System.Threading.Tasks;

namespace StoreApi.Data
{
    public interface IWriteObjects<T> where T : new()
    {
        Task WriteObject(T obj);
    }
}