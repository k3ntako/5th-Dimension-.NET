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
            
            string googleBooksApiKey = (string) apiKeys.GetValue("GoogleBooksApiKey");
            Environment.SetEnvironmentVariable("fd_GoogleBooksApiKey", googleBooksApiKey);

            string logDirectory = (string)apiKeys.GetValue("LogFilePath");

            if (logDirectory is null)
            {
                logDirectory = "./logs.log";
            }

            Environment.SetEnvironmentVariable("fd_LogFilePath", logDirectory);
        }
    }
}
