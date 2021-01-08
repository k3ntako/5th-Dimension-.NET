using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FifthDimension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/booksearch")]
    public class BookSearchController : ControllerBase
    {
        public BookSearchController()
        {
        }

        [HttpGet]
        public async Task<List<Book>> Get(string q)
        {
            var jsonIO = new JsonIO();
            var apiKeys = jsonIO.DeserializeFromRelativePath("./", "ApiKeys.json");
            string googleBooksApiKey = (string)apiKeys.GetValue("GoogleBooksApiKey");

            var fetcher = new Fetcher(new HttpClient(), jsonIO);
            var bookGenerator = new BookGenerator(new BookFormatter());
            var googleBooks = new GoogleBooks(fetcher, googleBooksApiKey, bookGenerator);

            var books = await googleBooks.Search(q);

            return books;
        }
    }
}
