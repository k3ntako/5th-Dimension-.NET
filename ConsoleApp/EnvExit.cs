using System;
using ConsoleApp.interfaces;

namespace ConsoleApp
{
    public class EnvExit : IEnvExit
    {
        public EnvExit()
        {
        }

        public void Exit(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
