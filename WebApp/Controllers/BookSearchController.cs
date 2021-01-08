using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Get(string q)
        {
            return q;
        }
    }
}
