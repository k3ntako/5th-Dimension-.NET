using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FifthDimension
{
    public class BookGenerator
    {
        readonly string[] strParams = new string[] {
            "title", "publisher", "description", "publishedDate"
        };
        BookFormatter bookFormatter;

        public BookGenerator(BookFormatter bookFormatter)
        {
            this.bookFormatter = bookFormatter;
        }

        public Book Create(JToken bookParams)
        {
            Dictionary<string, object> bookParamDict = new Dictionary<string, object>();

            bookParamDict.Add("id", bookParams.Value<string>("id"));

            var volumeInfo = bookParams.Value<JObject>("volumeInfo");
            foreach (var key in strParams)
            {
                bookParamDict.Add(key, volumeInfo.Value<string>(key));
            }

            bookParamDict.Add("pageCount", bookParams.Value<UInt32>("pageCount"));

            var authorsArr = GetArrParam(volumeInfo, "authors");
            bookParamDict.Add("authors", authorsArr);

            var categoriesArr = GetArrParam(volumeInfo, "categories");
            bookParamDict.Add("categories", categoriesArr);


            var identifiersJArray = (JArray) volumeInfo.GetValue("industryIdentifiers");
            if (identifiersJArray is null)
            {
                bookParamDict.Add("industryIdentifiers", null);
            }
            else 
            {
                var identifiersArr = identifiersJArray.ToObject<Dictionary<string, string>[]>();
                bookParamDict.Add("industryIdentifiers", identifiersArr);
            } 

            return new Book(bookParamDict, bookFormatter);
        }

        public string[] GetArrParam(JObject volumeInfo, string key)
        {
            var paramArr = (JArray) volumeInfo.GetValue(key);

            if (paramArr is null)
            {
                return null;
            }

            return paramArr.ToObject<string[]>();
        }
    }
}
