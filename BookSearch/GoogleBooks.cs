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

        public GoogleBooks(Fetcher fetcher, string ApiKey)
        {
            this.fetcher = fetcher;
            this.apiKey = ApiKey;
        }

        public async Task<List<Book>> Search(string input)
        {
            try
            {
                var response = await fetcher.HttpGet(GenerateVolumeUrl(input));
                var items = response.GetValue("items");

                List<Book> books = new List<Book>();

                foreach (var book in items)
                {
                    books.Add(new Book(book));
                }


                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        string GenerateVolumeUrl(string query)
        {
            var fields = "items(id,volumeInfo(title,publishedDate,industryIdentifiers,categories,authors,publisher,description,pageCount))";
            return $"{this.baseUrl}volumes?q={query}&fields={fields}&maxResults={5}&key={this.apiKey}";
        }
    }
}
