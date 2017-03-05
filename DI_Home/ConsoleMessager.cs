using System;

namespace DI_Home
{
    public class ConsoleMessager : IMessager
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}