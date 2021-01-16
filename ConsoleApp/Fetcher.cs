using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.interfaces;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class Fetcher : IFetcher
    {
        readonly HttpClient HttpClient;
        readonly IJsonIO JsonIO;

        public Fetcher(HttpClient httpClient, IJsonIO jsonIO)
        {
            HttpClient = httpClient;
            JsonIO = jsonIO;
        }

        public async Task<JObject> HttpGet(string url){
            try
            {
                var response = await HttpClient.GetStringAsync(url);
                return JsonIO.Deserialize(response);
            }
            catch (System.Exception ex)
            {
                Logger.WriteError(ex);
                throw;
            }
        }
    }
}
