using System;
using System.Diagnostics;

namespace Cipher.Core
{
    public class DebugLogger : ILogger
    {
        public void Error(string message)
        {
            Debug.WriteLine("------------------------------");
            Debug.WriteLine(message);
            Debug.WriteLine("------------------------------");
        }

        public void Error(Exception ex, string message)
        {
            Debug.WriteLine("------------------------------");
            Debug.WriteLine(message);
            Debug.WriteLine(ex);
            Debug.WriteLine("------------------------------");
        }
    }
}