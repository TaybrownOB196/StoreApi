using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StoreApi.Infra
{
    public abstract class DataFileModelReader<T> : IReadObjects<T> where T : new()
    {
        protected readonly string _fileName;
        protected string _cachedFile;
        protected bool _isCaching;
        public bool isCaching { get { return _isCaching; } }

        protected DataFileModelReader(string fileName, bool useCache)
        {
            _fileName = fileName;
            _cachedFile = String.Empty;
            _isCaching = useCache;
        }

        public Task<T> RetrieveObject()
        {
            ReadFile().ConfigureAwait(false);
            return ParseFile();
        }

        protected async Task<string> ReadFile() 
        {
            if (string.IsNullOrWhiteSpace(_cachedFile)) 
            {
                Char[] buffer;
                using (var sr = new StreamReader(_fileName)) 
                {
                    buffer = new Char[(int)sr.BaseStream.Length];
                    await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length).ConfigureAwait(false);
                    _cachedFile = new String(buffer);

                    return _cachedFile;
                }
            } 
            else
            {
                return _cachedFile;
            }
        }

        protected Task<T> ParseFile() 
        {
            return Task.Factory.StartNew(() => (T)JsonConvert.DeserializeObject(_cachedFile, typeof(T)));
        }
    }
}