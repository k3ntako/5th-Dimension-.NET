using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearch.Models;

namespace BookSearch
{
    public class Wrapper
    {
        ITextIO textIO;
        GoogleBooks googleBooks;

        public Wrapper(ITextIO textIO, GoogleBooks googleBooks)
        {
            this.textIO = textIO;
            this.googleBooks = googleBooks;
        }

        public async Task Start()
        {
            DisplayWelcome();

            var input = textIO.Prompt("Enter search term...");
            var books = await googleBooks.Search(input);

            PrintBooks(books);
        }

        void DisplayWelcome()
        {
            textIO.Print("Welcome to Book Search!");
        }

        void PrintBooks(List<Book> books)
        {
            if (books is null)
            {
                return;
            }

            foreach (var book in books)
            {
                textIO.Print(book.FormatAsString());
            }
        }
    }
}
