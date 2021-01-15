using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var textIO = new ConsoleIO();
                textIO.Clear();

                var jsonIO = new JsonIO();

                var envConfigurator = new EnvConfigurator(jsonIO);
                envConfigurator.SetEnvFromFile("./", "env.json");

                var fetcher = new Fetcher(new HttpClient(), jsonIO);
                var googleBookJsonParser = new GoogleBookJsonParser();
                var googleBooks = new GoogleBooks(fetcher, googleBookJsonParser);
                var appLoop = new AppLoop(textIO, googleBooks, new BookStringFormatter());

                var wrapper = new AppLoopStarter(textIO, appLoop);
                await wrapper.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Logger.WriteError(ex);
                Environment.Exit(1);
            }
        }
    }
}
