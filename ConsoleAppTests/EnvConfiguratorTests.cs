using System;
using ConsoleApp;
using ConsoleAppTests.mocks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ConsoleAppTests
{
    public class EnvConfiguratorTests
    {
        JsonIOMock JsonIOMock;

        [SetUp]
        public void Setup()
        {
            var mockObject = new JObject
            {
                { "GoogleBooksApiKey", "mock_key" },
                { "LogDirectory", "/logs/fifth-dimension/log.log" }
            };

            JsonIOMock = new JsonIOMock(mockObject);
        }

        [Test]
        public void Set_Env_From_File_Google_Books_Api_Key()
        {
            var envConfigurator = new EnvConfigurator(JsonIOMock);

            envConfigurator.SetEnvFromFile("./", "env.json");
            var googleApiKey = Environment.GetEnvironmentVariable("fd_GoogleBooksApiKey");

            Assert.NotNull(googleApiKey);
            Assert.AreEqual("mock_key", googleApiKey);
        }

        [Test]
        public void Set_Env_From_File_Log_Directory()
        {
            var envConfigurator = new EnvConfigurator(JsonIOMock);

            envConfigurator.SetEnvFromFile("./", "env.jso");
            var logDirectory = Environment.GetEnvironmentVariable("fd_LogDirectory");

            Assert.NotNull(logDirectory);
            Assert.AreEqual("/logs/fifth-dimension/log.log", logDirectory);
        }
    }
}
