using System;
using System.Collections.Generic;
using ConsoleApp;
using NUnit.Framework;

namespace ConsoleAppTests
{
    public class BookFormatterTests
    {
        Book book;

        [SetUp]
        public void Setup()
        {
            var bookParams = new Dictionary<string, object>();
            bookParams.Add("id", "123");
            bookParams.Add("title", ".NET For Smarties");
            bookParams.Add("authors", new string[] {"Henry Isaac Rowntree", "Joseph Rowntree"});
            bookParams.Add("publisher", "Nestlé");
            bookParams.Add("description", "A book for candies.");
            bookParams.Add("pageCount", (UInt32) 1);
            bookParams.Add("publishedDate", "1862");
            bookParams.Add("industryIdentifiers", null);
            bookParams.Add("categories", new string[] {"Candy", "Computer Programming"});


            book = new Book(bookParams, new BookFormatter());
        }

        [Test]
        public void FormatAsShortString_Should_Return_Expected_Fields()
        {
            var bookFormatter = new BookFormatter();
            var str = bookFormatter.FormatAsShortString(book);

            StringAssert.Contains(".NET For Smarties", str);
            StringAssert.Contains("Authors: Henry Isaac Rowntree, Joseph Rowntree", str);
            StringAssert.Contains("Publisher: Nestlé", str);
            StringAssert.Contains("Publish Date: 1862", str);
        }

        [Test]
        public void FormatAsString_Should_Return_Expected_Fields()
        {
            var bookFormatter = new BookFormatter();
            var str = bookFormatter.FormatAsString(book);

            StringAssert.Contains(".NET For Smarties", str);
            StringAssert.Contains("Authors: Henry Isaac Rowntree, Joseph Rowntree", str);
            StringAssert.Contains("Publisher: Nestlé", str);
            StringAssert.Contains("Description: A book for candies.", str);
            StringAssert.Contains("Page Count: 1", str);
            StringAssert.Contains("Publish Date: 1862", str);
            StringAssert.Contains("Categories: Candy, Computer Programming", str);
        }
    }
}