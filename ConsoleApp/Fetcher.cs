using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.interfaces;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class Fetcher
    {
        HttpClient httpClient;
        readonly IJsonIO jsonIO;

        public Fetcher(HttpClient httpClient, IJsonIO jsonIO)
        {
            this.httpClient = httpClient;
            this.jsonIO = jsonIO;
        }

        public async Task<JObject> HttpGet(string url){
            try
            {
                var response = await httpClient.GetStringAsync(url);
                return jsonIO.Deserialize(response);
            }
            catch (System.Exception ex)
            {
                Logger.WriteError(ex);
                throw;
            }
        }
    }
}
