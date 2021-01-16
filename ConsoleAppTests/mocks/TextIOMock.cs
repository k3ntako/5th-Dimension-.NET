using System;
using ConsoleApp;

namespace ConsoleAppTests.mocks
{
    public class TextIOMock : ITextIO
    {
        public MockCalls MockCalls = new MockCalls();
        public readonly string MockPrompt;

        public TextIOMock(string mockPrompt)
        {
            MockPrompt = mockPrompt;
        }

        public void Clear()
        {
            MockCalls.Add("Clear");
        }

        public void Error(string str)
        {
            MockCalls.AddWithSingleArgument("Error", str);
        }

        public void Error(Exception ex)
        {
            MockCalls.AddWithSingleArgument("Error", ex);
        }

        public void Print(string str)
        {
            MockCalls.AddWithSingleArgument("Print", str);
        }

        public string Prompt(string question)
        {
            MockCalls.AddWithSingleArgument("Prompt", question);
            return MockPrompt;
        }
    }
}
