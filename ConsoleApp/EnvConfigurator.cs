using System;
using ConsoleApp.interfaces;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class EnvConfigurator
    {
        private readonly IJsonIO JsonIO;
        public EnvConfigurator(IJsonIO jsonIO)
        {
            JsonIO = jsonIO;
        }

        public void SetEnvFromFile(string relativeTo, string path)
        {
            JObject apiKeys = JsonIO.DeserializeFromRelativePath(relativeTo, path);

            SetLogFilePath(apiKeys);
            SetGoogleBooksApiKey(apiKeys);
        }

        private void SetLogFilePath(JObject apiKeys)
        {
            string logDirectory = (string)apiKeys.GetValue("LogFilePath");

            if (logDirectory is null)
            {
                logDirectory = "./logs.log";
            }

            Environment.SetEnvironmentVariable("fd_LogFilePath", logDirectory);
        }

        private void SetGoogleBooksApiKey(JObject apiKeys)
        {
            string googleBooksApiKey = (string)apiKeys.GetValue("GoogleBooksApiKey");
            Environment.SetEnvironmentVariable("fd_GoogleBooksApiKey", googleBooksApiKey);

            if (googleBooksApiKey is null)
            {
                throw new Exception("Google Books API key is undefined");
            }
        }
    }
}
