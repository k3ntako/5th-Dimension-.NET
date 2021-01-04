using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Resources;
using System.Text.Json;
using System.Threading.Tasks;
namespace BookSearch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var consoleIO = new ConsoleIO();
            consoleIO.Clear();

            string ApiKeysPath = Path.GetRelativePath("./", "ApiKeys.json");
            string jsonStr = File.ReadAllText(ApiKeysPath);
            var apiKeys = JsonSerializer.Deserialize<ApiKeys>(jsonStr);

            var fetcher = new Fetcher(new HttpClient());
            var googleBooks = new GoogleBooks(fetcher, apiKeys.GoogleBooksApiKey);

            var wrapper = new Wrapper(consoleIO, googleBooks);
            await wrapper.Start();
        }
    }

    public class ApiKeys
    {
        public string GoogleBooksApiKey { get; set; }
    }
}
