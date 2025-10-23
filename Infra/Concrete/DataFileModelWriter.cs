using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace StoreApi.Infra
{
    public abstract class DataFileModelWriter<T> : IWriteObjects<T> where T : new()
    {
        protected readonly string _fileName;
        protected DataFileModelWriter(string fileName)
        {
            _fileName = fileName;   
        }

        protected string SerializeObject(T obj) 
        {
            return JsonSerializer.Serialize(obj);
        }

        public async Task WriteObject(T obj)
        {
            var json = SerializeObject(obj);
            var encode = new UnicodeEncoding();
            byte[] byteArray = encode.GetBytes(json);
            using var writer = new StreamWriter(_fileName);
            await writer.BaseStream.WriteAsync(byteArray, 0, byteArray.Length);
        }
    }
}