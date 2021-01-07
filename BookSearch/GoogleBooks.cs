using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearch.Models;

namespace BookSearch
{
    public class GoogleBooks
    {
        readonly string baseUrl = "https://www.googleapis.com/books/v1/";
        readonly string apiKey;
        readonly Fetcher fetcher;
        readonly BookGenerator bookGenerator;

        public GoogleBooks(Fetcher fetcher, string apiKey, BookGenerator bookGenerator)
        {
            this.fetcher = fetcher;
            this.apiKey = apiKey;
            this.bookGenerator = bookGenerator;
        }

        public async Task<List<Book>> Search(string input)
        {
          
            var response = await fetcher.HttpGet(GenerateVolumeUrl(input));
            var items = response.GetValue("items");

            List<Book> books = new List<Book>();

            foreach (var book in items)
            {
                books.Add(bookGenerator.Create(book));
            }


            return books;
        }

        string GenerateVolumeUrl(string query)
        {
            var fields = "items(id,volumeInfo(title,publishedDate,industryIdentifiers,categories,authors,publisher,description,pageCount))";
            return $"{baseUrl}volumes?q={query}&fields={fields}&maxResults={5}&key={apiKey}";
        }
    }
}
