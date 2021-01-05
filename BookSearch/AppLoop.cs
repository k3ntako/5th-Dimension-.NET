﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearch.Models;


namespace BookSearch
{
    public class AppLoop
    {
        ITextIO textIO;
        GoogleBooks googleBooks;

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
                        var books = await PromptSearch();
                        PrintBooks(books);
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

        async Task<List<Book>> PromptSearch()
        {
            var input = textIO.Prompt("Enter search term...");
            return await googleBooks.Search(input);
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