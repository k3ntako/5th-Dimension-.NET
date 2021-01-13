using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class GoogleBooks
    {
        readonly string BaseUrl = "https://www.googleapis.com/books/v1/";
        readonly string ApiKey;
        readonly Fetcher Fetcher;
        readonly BookGenerator BookGenerator;

        public GoogleBooks(Fetcher fetcher, string apiKey, BookGenerator bookGenerator)
        {
            Fetcher = fetcher;
            ApiKey = apiKey;
            BookGenerator = bookGenerator;
        }

        public async Task<List<Book>> Search(string input)
        {
          
            var response = await Fetcher.HttpGet(GenerateVolumeUrl(input));
            var items = response.GetValue("items");

            List<Book> books = new List<Book>();

            foreach (var book in items)
            {
                books.Add(BookGenerator.Create(book));
            }


            return books;
        }

        string GenerateVolumeUrl(string query)
        {
            var fields = "items(id,volumeInfo(title,publishedDate,industryIdentifiers,categories,authors,publisher,description,pageCount))";
            return $"{BaseUrl}volumes?q={query}&fields={fields}&maxResults={5}&key={ApiKey}";
        }
    }
}
