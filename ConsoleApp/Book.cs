using System;
using System.Collections.Generic;

namespace FifthDimension
{
    public class Book
    {
        public string Id { get; }
        public string Title { get; }
        public string[] Authors { get; }
        public string Publisher { get; }
        public string Description { get; }
        public UInt32 PageCount { get; }
        public string PublishedDate { get; }
        public Dictionary<string, string>[] IndustryIdentifiers { get; }
        public string[] Categories { get; }

        readonly BookFormatter BookFormatter;

        public Book(Dictionary<string, object> bookParams, BookFormatter bookFormatter)
        {
            Id = (string) bookParams["id"];
            Title = (string) bookParams["title"];
            Authors = (string[]) bookParams["authors"];
            Publisher = (string) bookParams["publisher"];
            Description = (string) bookParams["description"];
            PageCount = (UInt32) bookParams["pageCount"];
            PublishedDate = (string)bookParams["publishedDate"];
            IndustryIdentifiers = (Dictionary<string, string>[])bookParams["industryIdentifiers"];
            Categories = (string[])bookParams["categories"];

            BookFormatter = bookFormatter;
        }

        public string FormatAsString()
        {
            return BookFormatter.FormatAsString(this);
        }

        public string FormatAsShortString()
        {
            return BookFormatter.FormatAsShortString(this);
        }
    }
}

