using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var textIO = new ConsoleIO();
            textIO.Clear();

            var jsonIO = new JsonIO();
            var apiKeys = jsonIO.DeserializeFromRelativePath("./", "ApiKeys.json");
            string googleBooksApiKey = (string) apiKeys.GetValue("GoogleBooksApiKey");

            var fetcher = new Fetcher(new HttpClient(), jsonIO);
            var googleBookJsonParser = new GoogleBookJsonParser(new BookStringFormatter());
            var googleBooks = new GoogleBooks(fetcher, googleBooksApiKey, googleBookJsonParser);
            var appLoop = new AppLoop(textIO, googleBooks);

            var wrapper = new AppLoopStarter(textIO, appLoop);
            await wrapper.Start();
        }
    }
}
