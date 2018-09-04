using System.Threading.Tasks;

namespace StoreApi.Infra
{
    public interface IWriteObjects<T> where T : new()
    {
        Task WriteObject(T obj);
    }
}