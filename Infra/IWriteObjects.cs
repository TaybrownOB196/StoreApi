namespace StoreApi.Infra
{
    public interface IWriteObjects<T> where T : new()
    {
        void WriteObject(T obj);
    }
}