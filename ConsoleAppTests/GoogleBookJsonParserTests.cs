using System;
using System.Collections.Generic;
using ConsoleApp;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ConsoleAppTests
{
    public class GoogleBookJsonParserTests
    {
        JObject bookJson;

        [SetUp]
        public void Setup()
        {
            bookJson = new JObject();
            bookJson.Add("id", "123");

            var volumeInfo = new JObject();

            volumeInfo.Add("title", ".NET For Smarties");
            volumeInfo.Add("publisher", "Nestlé");
            volumeInfo.Add("description", "A book for candies.");
            volumeInfo.Add("pageCount", 1);
            volumeInfo.Add("publishedDate", "1862");
            volumeInfo.Add("industryIdentifiers", null);

            var authors = new JArray
            {
                "Henry Isaac Rowntree",
                "Joseph Rowntree"
            };
            volumeInfo.Add("authors", authors);

            var categories = new JArray
            {
                "Candy",
                "Computer Programming"
            };
            volumeInfo.Add("categories", categories);

            bookJson.Add("volumeInfo", volumeInfo);
        }

        [Test]
        public void Parse_Should_Return_Dictionary()
        {
            var googleBookJsonParser = new GoogleBookJsonParser();
            Dictionary<string, object> bookParams = googleBookJsonParser.Parse(bookJson);

            Assert.AreEqual("123", bookParams["id"]);
            Assert.AreEqual(".NET For Smarties", bookParams["title"]);
            Assert.AreEqual("Nestlé", bookParams["publisher"]);
            Assert.AreEqual("A book for candies.", bookParams["description"]);
            Assert.AreEqual(1, bookParams["pageCount"]);
            Assert.AreEqual("1862", bookParams["publishedDate"]);
            Assert.Null(bookParams["industryIdentifiers"]);
        }
    }
}