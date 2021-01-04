using System;
namespace BookSearch
{
    public class ConsoleIO
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
    }
}
