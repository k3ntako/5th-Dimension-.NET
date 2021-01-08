using System.Threading.Tasks;

namespace FifthDimension
{
    public class AppLoopStarter
    {
        readonly ITextIO TextIO;
        readonly AppLoop AppLoop;

        public AppLoopStarter(ITextIO textIO, AppLoop appLoop)
        {
            TextIO = textIO;
            AppLoop = appLoop;
        }

        public async Task Start()
        {
            PrintWelcome();
            await AppLoop.Start();
        }

        void PrintWelcome()
        {
            TextIO.Print("Welcome to Book Search!");
        }
    }
}
