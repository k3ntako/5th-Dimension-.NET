using System;
namespace ConsoleApp
{
    public class ConsoleIO : ITextIO
    {
        public void Print(string str) {
            Console.WriteLine(str);
        }

        public string Prompt(string question)
        {
            Print(question);
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Error(string str)
        {
            Console.WriteLine(str);
        }

        public void Error(Exception ex)
        {
            Console.WriteLine(ex.Message);  
        }
    }
}
