using System;
using System.Threading.Tasks;

namespace BookSearch
{
    public class GoogleBooks
    {
        readonly string baseUrl = "https://www.googleapis.com/books/v1/";
        readonly string apiKey;
        readonly Fetcher fetcher;

        public GoogleBooks(Fetcher fetcher, string ApiKey)
        {
            this.fetcher = fetcher;
            this.apiKey = ApiKey;
        }

        public async Task<object> Search(string input)
        {
            object response = await fetcher.HttpGet(generateVolumeUrl(input));

            return response;
        }

        string generateVolumeUrl(string query)
        {
            return $"{this.baseUrl}volumes?q={query}&key={this.apiKey}";
        }
    }
}
