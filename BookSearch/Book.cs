using System;
using System.Collections.Generic;

namespace BookSearch
{
    public class Book
    {
        public readonly string id;
        public readonly string title;
        public readonly string[] authors;
        public readonly string publisher;
        public readonly string description;
        public readonly UInt32 pageCount;
        public readonly string publishedDate;
        public readonly Dictionary<string, string>[] industryIdentifiers;
        public readonly string[] categories;

        readonly BookFormatter bookFormatter;

        public Book(Dictionary<string, object> bookParams, BookFormatter bookFormatter)
        {
            id = (string) bookParams["id"];
            title = (string) bookParams["title"];
            authors = (string[]) bookParams["authors"];
            publisher = (string) bookParams["publisher"];
            description = (string) bookParams["description"];
            pageCount = (UInt32) bookParams["pageCount"];
            publishedDate = (string)bookParams["publishedDate"];
            industryIdentifiers = (Dictionary<string, string>[])bookParams["industryIdentifiers"];
            categories = (string[])bookParams["categories"];

            this.bookFormatter = bookFormatter;
        }

        public string FormatAsString()
        {
            return bookFormatter.FormatAsString(this);
        }

        public string FormatAsShortString()
        {
            return bookFormatter.FormatAsShortString(this);
        }
    }
}

