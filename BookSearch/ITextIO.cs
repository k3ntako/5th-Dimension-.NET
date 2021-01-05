using System;
namespace BookSearch
{
    public interface ITextIO
    {
        public void Print(string str);
        public string Prompt(string question);
        public void Clear();
        public void Error(Exception ex);
    }
}
