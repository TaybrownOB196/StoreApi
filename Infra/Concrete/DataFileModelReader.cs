using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace StoreApi.Infra
{
    public abstract class DataFileModelReader<T> : IReadObjects<T> where T : new()
    {
        private readonly string _fileName;

        protected DataFileModelReader(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<T> RetrieveObject()
        {
            var fileString = await ReadFile();
            return ParseFile(fileString);
        }

        private async Task<string> ReadFile() 
        {
            using var reader = new StreamReader(_fileName);
            return await reader.ReadToEndAsync();
        }

        private T ParseFile(string fileString) => JsonSerializer.Deserialize<T>(fileString);
    }
}