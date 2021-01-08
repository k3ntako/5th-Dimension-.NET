using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FifthDimension
{
    public class AppLoop
    {
        readonly ITextIO TextIO;
        readonly GoogleBooks GoogleBooks;

        public AppLoop(ITextIO textIO, GoogleBooks googleBooks)
        {
            TextIO = textIO;
            GoogleBooks = googleBooks;
        }

        public async Task Start()
        {
            while (true)
            {
                var selection = PromptMainMenu();
                TextIO.Clear();

                switch (selection)
                {
                    case "1":
                        var searchTerm = PromptSearch();
                        var books = await FetchSearch(searchTerm);
                        PrintBooks(searchTerm, books);
                        break;
                    case "2":
                        TextIO.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        TextIO.Print("Could not undestand your input. Please try again.");
                        break;
                }
            }
        }

        string PromptMainMenu()
        {
            TextIO.Print("-- Main Menu --");
            TextIO.Print("1. Search");
            TextIO.Print("2. Exit");

            return TextIO.Prompt("Enter the number:");
        }

        string PromptSearch()
        {
            TextIO.Clear();
            return TextIO.Prompt("Enter search term...");
        }

        async Task<List<Book>> FetchSearch(string searchTerm)
        {
            try
            {
                return await GoogleBooks.Search(searchTerm);
            }
            catch (Exception)
            {
                TextIO.Error("There was a problem getting the search results. Please try again.");
                return null;
            }
        }

        void PrintBooks(string searchTerm, List<Book> books)
        {
            if (books is null)
            {
                return;
            }

            TextIO.Clear();
            TextIO.Print($"Showing results for {searchTerm}:{Environment.NewLine}");

            foreach (var book in books)
            {
                TextIO.Print(book.FormatAsShortString());
            }
        }
    }
}
