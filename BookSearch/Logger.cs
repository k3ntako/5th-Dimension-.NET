using System;
using System.IO;

namespace BookSearch
{
    public class Logger
    {
        public Logger()
        {
        }

        static public void WriteError(string message)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine($"  : {message}");
                w.WriteLine("-------------------------------");
            }
        }

        static public void WriteError(Exception ex)
        {
            var utcNow = DateTime.UtcNow;

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{utcNow.ToLongTimeString()} {utcNow.ToLongDateString()} (UTC)");
                w.WriteLine($"  : Message: {ex.Message}");
                w.WriteLine($"  : Target Site: {ex.TargetSite}");
                w.WriteLine($"  : Stack Trace: {ex.StackTrace}");
                w.WriteLine("-------------------------------");
            }
        }
    }
}

// "using" statement
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement

// Write to log
// https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-open-and-append-to-a-log-file
