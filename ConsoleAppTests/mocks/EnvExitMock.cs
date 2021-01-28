using System;
using ConsoleApp.interfaces;

namespace ConsoleAppTests.mocks
{
    public class EnvExitMock : IEnvExit
    {
        public int LastExitCode;
        public int ExitCallCount = 0;
        public EnvExitMock()
        {
        }

        public void Exit(int exitCode)
        {
            LastExitCode = exitCode;
            ExitCallCount++;
            Console.WriteLine(ExitCallCount);
        }
    }
}
