using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BookSearch.Models
{
    public class Book
    {
        readonly string id;
        readonly string title;
        readonly string[] authors;
        readonly string publisher;
        readonly string description;
        readonly UInt32 pageCount;
        readonly string publishedDate;
        readonly Dictionary<string, string>[] industryIdentifiers;
        readonly string[] categories;

        public Book(Dictionary<string, object> bookParams)
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
            
        }

        public string FormatAsString()
        {
            try
            {
                var bookStr = FormatField(title ?? "[No Title]");
                bookStr += FormatField("Authors", authors);
                bookStr += FormatField("Publisher", publisher);
                bookStr += FormatField("Description", description, 150);
                bookStr += FormatField("Page Count", pageCount.ToString());
                bookStr += FormatField("Publish Date", publishedDate);
                bookStr += FormatField("Categories", categories);

                //Dictionary<string, string>[] industryIdentifiers;

                return bookStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        static string FormatField(string fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldVal}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string fieldVal)
        {
            if(fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {fieldVal}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string[] fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {string.Join(", ", fieldVal)}{Environment.NewLine}";
        }

        static string FormatField(string fieldTitle, string fieldVal, int maxLength)
        {
            if (fieldVal is null)
            {
                return "";
            }
            else if (fieldVal.Length <= maxLength)
            {
                return $"{fieldTitle}: {fieldVal}{Environment.NewLine}";
            }

            var shortVal = fieldVal.Substring(0, Math.Min(fieldVal.Length, maxLength));
            return $"{fieldTitle}: {shortVal}...{Environment.NewLine}";
        }
    }
}

