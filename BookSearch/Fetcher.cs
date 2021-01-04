using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace BookSearch
{
    public class Fetcher
    {
        HttpClient httpClient;

        public Fetcher(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<object> HttpGet(string url){
            return await this.httpClient.GetFromJsonAsync<object>(url);
        }
    }
}
