using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearch.Models;

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

            var input = consoleIO.Prompt("Enter search term...");
            var books = await googleBooks.Search(input);

            PrintBooks(books);
        }

        void DisplayWelcome()
        {
            consoleIO.Print("Welcome to Book Search!");
        }

        void PrintBooks(List<Book> books)
        {
            if (books is null)
            {
                return;
            }

            foreach (var book in books)
            {
                consoleIO.Print(book.FormatAsString());
            }
        }
    }
}
