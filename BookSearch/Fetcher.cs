using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BookSearch
{
    public class Fetcher
    {
        HttpClient httpClient;
        readonly JsonIO jsonIO;

        public Fetcher(HttpClient httpClient, JsonIO jsonIO)
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
