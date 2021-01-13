using System;
namespace ConsoleApp
{
    public interface ITextIO
    {
        public void Print(string str);
        public string Prompt(string question);
        public void Clear();
        public void Error(string str);
        public void Error(Exception ex);
    }
}
