using System;
using System.Collections.Generic;
namespace ConsoleAppTests.mocks
{
    public class MockMethodCall
    {
        public string MethodName;
        public List<dynamic> Arguments;

        public MockMethodCall(string methodName)
        {
            MethodName = methodName;
            Arguments = null;
        }

        public MockMethodCall(string methodName, List<dynamic> arguments)
        {
            MethodName = methodName;
            Arguments = arguments;
        }
    }
}
