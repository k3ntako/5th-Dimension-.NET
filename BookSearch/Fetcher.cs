using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookSearch
{
    public class Fetcher
    {
        HttpClient httpClient;
        JsonIO jsonIO;

        public Fetcher(HttpClient httpClient, JsonIO jsonIO)
        {
            this.httpClient = httpClient;
            this.jsonIO = jsonIO;
        }

        public async Task<JObject> HttpGet(string url){
            var response = await this.httpClient.GetStringAsync(url);
            return jsonIO.Deserialize(response);
        }
    }
}
