using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            return JsonConvert.SerializeObject(obj);
        }

        public async Task WriteObject(T obj)
        {
            var json = SerializeObject(obj);
            UnicodeEncoding encode = new UnicodeEncoding();
            byte[] byteArray = encode.GetBytes(json);
            using (var sr = new StreamReader(_fileName))     
            {
                await sr.BaseStream.WriteAsync(byteArray, 0, byteArray.Length);
            }
        }
    }
}