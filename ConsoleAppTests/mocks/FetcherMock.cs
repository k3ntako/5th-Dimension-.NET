using System;
using System.Threading.Tasks;
using ConsoleApp.interfaces;
using Newtonsoft.Json.Linq;

namespace ConsoleAppTests.mocks
{
    public class FetcherMock : IFetcher
    {
        readonly JObject MockReturn;
        public FetcherMock(JObject mockReturn)
        {
            MockReturn = mockReturn;
        }

        // Disables warning for having an async method without await
        // This is a mock method that is trying to mimic the original Fetcher
        #pragma warning disable CS1998
        public async Task<JObject> HttpGet(string url)
        #pragma warning restore CS1998
        {
            return MockReturn;
        }
    }
}
