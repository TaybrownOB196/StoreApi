using System.Text.Json;

namespace StoreApi.Data
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

        private T ParseFile(string fileString)
        {
            T toReturn = new T();
            try
            {
                toReturn = JsonSerializer.Deserialize<T>(fileString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine(fileString);
                Console.WriteLine(ex.Message);
            }

            return toReturn;
        }
    }
}