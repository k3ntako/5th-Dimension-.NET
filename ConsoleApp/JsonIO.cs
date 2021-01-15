using System.IO;
using ConsoleApp.interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class JsonIO : IJsonIO
    {
        public JsonIO()
        {
        }

        public JObject DeserializeFromRelativePath(string relativeTo, string path) {
            string filePath = Path.GetRelativePath(relativeTo, path);
            string jsonStr = File.ReadAllText(filePath);

            return Deserialize(jsonStr);
        }

        public JObject Deserialize(string jsonStr)
        {
            return (JObject) JsonConvert.DeserializeObject(jsonStr);
        }

    }
}
