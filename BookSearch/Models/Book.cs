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

        public Book(JToken bookParams)
        {
            try
            {
                id = bookParams.Value<string>("id");

                var volumeInfo = bookParams.Value<JObject>("volumeInfo");

                title = volumeInfo.Value<string>("title");
                publisher = volumeInfo.Value<string>("publisher");
                description = volumeInfo.Value<string>("description");
                pageCount = volumeInfo.Value<UInt32>("pageCount");
                publishedDate = volumeInfo.Value<string>("publishedDate");

                var authorsJArray = (JArray)volumeInfo.GetValue("authors");
                if (authorsJArray is not null)
                {
                    authors = authorsJArray.ToObject<string[]>();
                }

                var identifiersJArray = (JArray)volumeInfo.GetValue("industryIdentifiers");
                if(identifiersJArray is not null)
                {
                    industryIdentifiers = identifiersJArray.ToObject<Dictionary<string, string>[]>();
                }

                var categoriesJArray = (JArray)volumeInfo.GetValue("categories");
                if(categoriesJArray is not null)
                {
                    categories = categoriesJArray.ToObject<string[]>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
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

