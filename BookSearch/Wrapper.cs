using System;
using System.Threading.Tasks;

namespace BookSearch
{
    public class Wrapper
    {
        ConsoleIO consoleIO;
        GoogleBooks googleBooks;

        public Wrapper(ConsoleIO consoleIO, GoogleBooks googleBooks)
        {
            this.consoleIO = consoleIO;
            this.googleBooks = googleBooks;
        }

        public async Task Start()
        {
            DisplayWelcome();

            var input = consoleIO.Prompt("Search...");
            await googleBooks.Search(input);

            Console.WriteLine("Wrapper done");
        }

        void DisplayWelcome()
        {
            this.consoleIO.Print("Welcome to Google Books");
        }
    }
}
