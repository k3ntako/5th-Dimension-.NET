using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace BookSearch.Models
{
    public class Book
    {
        string id;
        string title;
        string[] authors;
        string publisher;
        string description;
        UInt32 pageCount;
        string publishedDate;
        Dictionary<string, string>[] industryIdentifiers;
        string[] categories;

        public Book(JToken bookParams)
        {
            try
            {
                this.id = bookParams.Value<string>("id");

                var volumeInfo = bookParams.Value<JObject>("volumeInfo");

                this.title = volumeInfo.Value<string>("title");
                this.publisher = volumeInfo.Value<string>("publisher");
                this.description = volumeInfo.Value<string>("description");
                this.pageCount = volumeInfo.Value<UInt32>("pageCount");
                this.publishedDate = volumeInfo.Value<string>("publishedDate");

                var authorsJArray = (JArray)volumeInfo.GetValue("authors");
                if (authorsJArray is not null)
                {
                    this.authors = authorsJArray.ToObject<string[]>();
                }

                var identifiersJArray = (JArray)volumeInfo.GetValue("industryIdentifiers");
                if(identifiersJArray is not null)
                {
                    this.industryIdentifiers = identifiersJArray.ToObject<Dictionary<string, string>[]>();
                }

                var categoriesJArray = (JArray)volumeInfo.GetValue("categories");
                if(categoriesJArray is not null)
                {
                    this.categories = categoriesJArray.ToObject<string[]>();
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

        string FormatField(string fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldVal}{Environment.NewLine}";
        }

        string FormatField(string fieldTitle, string fieldVal)
        {
            if(fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {fieldVal}{Environment.NewLine}";
        }

        string FormatField(string fieldTitle, string[] fieldVal)
        {
            if (fieldVal is null)
            {
                return "";
            }

            return $"{fieldTitle}: {String.Join(", ", fieldVal)}{Environment.NewLine}";
        }

        string FormatField(string fieldTitle, string fieldVal, int maxLength)
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

