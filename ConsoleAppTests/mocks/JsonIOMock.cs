using System;
using ConsoleApp.interfaces;
using Newtonsoft.Json.Linq;

namespace ConsoleAppTests.mocks
{
    public class JsonIOMock : IJsonIO
    {
        readonly JObject MockObject;

        public JsonIOMock(JObject mockObject)
        {
            MockObject = mockObject;
        }

        public JObject Deserialize(string jsonStr)
        {
            return MockObject;
        }

        public JObject DeserializeFromRelativePath(string relativeTo, string path)
        {
            return MockObject;
        }
    }
}
