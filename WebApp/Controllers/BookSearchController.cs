using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp;
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
            var fetcher = new Fetcher(new HttpClient(), new JsonIO());
            var googleBookJsonParser = new GoogleBookJsonParser();
            var googleBooks = new GoogleBooks(fetcher, googleBookJsonParser);

            var books = await googleBooks.Search(q);

            return books;
        }
    }
}
