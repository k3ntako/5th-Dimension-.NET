using System;
using System.Threading.Tasks;
using ConsoleApp;
using ConsoleAppTests.mocks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ConsoleAppTests
{
    public class AppLoopTests
    {
        [Test]
        public async Task Start_Should_Exit_Given_2Async()
        {
            var mockFetchReturn = new JObject();
            var googleBooks = new GoogleBooks(new FetcherMock(mockFetchReturn), new GoogleBookJsonParser());
            var envExit = new EnvExitMock();

            var appLoop = new AppLoop(
                new TextIOMock("2"),
                googleBooks,
                new BookStringFormatter(),
                envExit
            );

            await appLoop.Start();

            Assert.AreEqual(0, envExit.LastExitCode);
            Assert.AreEqual(1, envExit.ExitCallCount);
        }
    }
}