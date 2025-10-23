using System.Text;
using System.Text.Json;

namespace StoreApi.Data
{
    public abstract class DataFileModelWriter<T> : IWriteObjects<T> where T : new()
    {
        protected readonly string _fileName;
        protected DataFileModelWriter(string fileName)
        {
            _fileName = fileName;   
        }

        public async Task WriteObject(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine(json);
            using var writer = new StreamWriter(_fileName);
            Console.WriteLine(writer.Encoding);
            await writer.WriteAsync(json);
        }
    }
}