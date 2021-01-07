using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FifthDimension
{
    public class AppLoop
    {
        readonly ITextIO textIO;
        readonly GoogleBooks googleBooks;

        public AppLoop(ITextIO textIO, GoogleBooks googleBooks)
        {
            this.textIO = textIO;
            this.googleBooks = googleBooks;
        }

        public async Task Start()
        {
            while (true)
            {
                var selection = PromptMainMenu();
                textIO.Clear();

                switch (selection)
                {
                    case "1":
                        var searchTerm = PromptSearch();
                        var books = await FetchSearch(searchTerm);
                        PrintBooks(searchTerm, books);
                        break;
                    case "2":
                        textIO.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        textIO.Print("Could not undestand your input. Please try again.");
                        break;
                }
            }
        }

        string PromptMainMenu()
        {
            textIO.Print("-- Main Menu --");
            textIO.Print("1. Search");
            textIO.Print("2. Exit");

            return textIO.Prompt("Enter the number:");
        }

        string PromptSearch()
        {
            textIO.Clear();
            return textIO.Prompt("Enter search term...");
        }

        async Task<List<Book>> FetchSearch(string searchTerm)
        {
            try
            {
                return await googleBooks.Search(searchTerm);
            }
            catch (Exception)
            {
                textIO.Error("There was a problem getting the search results. Please try again.");
                return null;
            }
        }

        void PrintBooks(string searchTerm, List<Book> books)
        {
            if (books is null)
            {
                return;
            }

            textIO.Clear();
            textIO.Print($"Showing results for {searchTerm}:{Environment.NewLine}");

            foreach (var book in books)
            {
                textIO.Print(book.FormatAsShortString());
            }
        }
    }
}
