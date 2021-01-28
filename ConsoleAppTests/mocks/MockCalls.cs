using System;
using System.Collections.Generic;

namespace ConsoleAppTests.mocks
{
    public class MockCalls
    {
        public List<MockMethodCall> MethodsCalled;
        public MockCalls()
        {
            MethodsCalled = new List<MockMethodCall>();
        }

        // Find the first method call with the same method name and at least one
        // of the argument matches the arg passed in.
        public int FindMethodCall(string method, string arg)
        {
            var index = 0;
            foreach (var methodCall in MethodsCalled)
            {
                var isMethod = methodCall.MethodName.Equals(method);

                var hasArg = false;
                if(isMethod && methodCall.Arguments is not null)
                {
                    hasArg = methodCall.Arguments.Contains(arg);
                }

                if (isMethod && hasArg)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public void Add(string methodName)
        {
            var mockMethodCall = new MockMethodCall(methodName);
            MethodsCalled.Add(mockMethodCall);
        }

        public void AddWithSingleArgument(string methodName, dynamic argument)
        {
            List<dynamic> argumentList = new List<dynamic> { argument };
            var mockMethodCall = new MockMethodCall(methodName, argumentList);
            MethodsCalled.Add(mockMethodCall);
        }

        public void AddWithMultipleArguments(string methodName, List<dynamic> arguments)
        {
            var mockMethodCall = new MockMethodCall(methodName, arguments);
            MethodsCalled.Add(mockMethodCall);
        }
    }
}