using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookSearch
{
    public class JsonIO
    {
        public JsonIO()
        {
        }

        public dynamic DeserializeFromRelativePath(string relativeTo, string path) {
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
