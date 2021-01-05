using System.Threading.Tasks;

namespace BookSearch
{
    public class AppLoopStarter
    {
        ITextIO textIO;
        AppLoop appLoop;

        public AppLoopStarter(ITextIO textIO, AppLoop appLoop)
        {
            this.textIO = textIO;
            this.appLoop = appLoop;
        }

        public async Task Start()
        {
            PrintWelcome();
            await appLoop.Start();
        }

        void PrintWelcome()
        {
            textIO.Print("Welcome to Book Search!");
        }
    }
}
