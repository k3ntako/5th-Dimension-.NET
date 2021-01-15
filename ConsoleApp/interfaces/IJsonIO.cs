using System;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.interfaces
{
    public interface IJsonIO
    {
        JObject DeserializeFromRelativePath(string relativeTo, string path);
        JObject Deserialize(string jsonStr);
    }
}
