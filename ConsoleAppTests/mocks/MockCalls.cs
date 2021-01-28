using System;
using System.Collections.Generic;

namespace ConsoleAppTests.mocks
{
    public class MockCalls
    {
        List<MockMethodCall> MethodsCalled;
        public MockCalls()
        {
            MethodsCalled = new List<MockMethodCall>();
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