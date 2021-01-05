using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookSearch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var consoleIO = new ConsoleIO();
            consoleIO.Clear();

            var jsonIO = new JsonIO();
            var apiKeys = jsonIO.DeserializeFromRelativePath("./", "ApiKeys.json");
            string googleBooksApiKey = (string) apiKeys.GetValue("GoogleBooksApiKey");

            var fetcher = new Fetcher(new HttpClient(), jsonIO);
            var googleBooks = new GoogleBooks(fetcher, googleBooksApiKey);

            var wrapper = new Wrapper(consoleIO, googleBooks);
            await wrapper.Start();
        }
    }
}
