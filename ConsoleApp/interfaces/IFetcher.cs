using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.interfaces
{
    public interface IFetcher
    {
        public Task<JObject> HttpGet(string url);
    }
}



