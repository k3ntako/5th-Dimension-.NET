using System;
using System.Collections.Generic;
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
        public async Task Start_Should_Exit_Given_2()
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



        [Test]
        public async Task Start_Should_Ask_To_Search_Given_1()
        {
            var mockFetchReturn = new JObject();
            var googleBooks = new GoogleBooks(new FetcherMock(mockFetchReturn), new GoogleBookJsonParser());
            var envExit = new EnvExitMock();
            var textIO = new TextIOMock(new List<string> { "1", "a search term", "2" });

            var appLoop = new AppLoop(
                textIO,
                googleBooks,
                new BookStringFormatter(),
                envExit
            );

            await appLoop.Start();

            int methodCallIdx = textIO.MockCalls.FindMethodCall("Prompt", "Enter search term...");
            Assert.GreaterOrEqual(methodCallIdx, 0);
        }
    }
}