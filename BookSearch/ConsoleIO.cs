using System;
namespace BookSearch
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

        public void Error(Exception ex)
        {
            Console.WriteLine(ex.ToString());  
        }
    }
}
