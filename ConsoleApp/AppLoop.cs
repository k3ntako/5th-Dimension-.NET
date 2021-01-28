using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.interfaces;

namespace ConsoleApp
{
    public class AppLoop
    {
        readonly ITextIO TextIO;
        readonly GoogleBooks GoogleBooks;
        readonly BookStringFormatter BookStringFormatter;
        readonly IEnvExit EnvExit;

        public AppLoop(
            ITextIO textIO,
            GoogleBooks googleBooks,
            BookStringFormatter bookStringFormatter,
            IEnvExit envExit
        )
        {
            TextIO = textIO;
            GoogleBooks = googleBooks;
            BookStringFormatter = bookStringFormatter;
            EnvExit = envExit;
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
                        goto Exit;
                    default:
                        TextIO.Print("Could not undestand your input. Please try again.");
                        break;
                }
            }

            Exit: EnvExit.Exit(0);
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
                TextIO.Print(BookStringFormatter.FormatAsShortString(book));
            }
        }
    }
}
