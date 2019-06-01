using System;

namespace Cipher.Core
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("------------------------------");
        }

        public void Error(Exception ex, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(ex);
            Console.WriteLine("------------------------------");
        }
    }
}