using System;
using System.Collections.Generic;
using ConsoleApp;

namespace ConsoleAppTests.mocks
{
    public class TextIOMock : ITextIO
    {
        public MockCalls MockCalls = new MockCalls();
        public readonly List<string> MockPrompts;
        int MockPromptIndex = 0;

        public TextIOMock(string mockPrompt)
        {
            MockPrompts = new List<string> { mockPrompt };
        }

        public TextIOMock(List<string> mockPrompts)
        {
            MockPrompts = mockPrompts;
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
            var mockPromptResponse = MockPrompts[MockPromptIndex];

            if(MockPromptIndex < MockPrompts.Count - 1)
            {
                MockPromptIndex++;
            }

            return mockPromptResponse;
        }
    }
}
