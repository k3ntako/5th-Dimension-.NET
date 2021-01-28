using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class GoogleBookJsonParser
    {
        readonly string[] strParams = new string[] {
            "title", "publisher", "description", "publishedDate"
        };

        public GoogleBookJsonParser()
        {
        }

        public Dictionary<string, object> Parse(JToken bookParams)
        {
            Dictionary<string, object> bookParamDict = new Dictionary<string, object>();

            bookParamDict.Add("id", bookParams.Value<string>("id"));

            var volumeInfo = bookParams.Value<JObject>("volumeInfo");
            foreach (var key in strParams)
            {
                bookParamDict.Add(key, volumeInfo.Value<string>(key));
            }

            bookParamDict.Add("pageCount", volumeInfo.Value<UInt32>("pageCount"));

            var authorsArr = GetArrParam(volumeInfo, "authors");
            bookParamDict.Add("authors", authorsArr);

            var categoriesArr = GetArrParam(volumeInfo, "categories");
            bookParamDict.Add("categories", categoriesArr);


            var identifiersJArray = volumeInfo.GetValue("industryIdentifiers");
            if (identifiersJArray is null)
            {
                bookParamDict.Add("industryIdentifiers", null);
            }
            else 
            {
                var identifiersArr = identifiersJArray.ToObject<Dictionary<string, string>[]>();
                bookParamDict.Add("industryIdentifiers", identifiersArr);
            }

            return bookParamDict;
        }

        string[] GetArrParam(JObject volumeInfo, string key)
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
