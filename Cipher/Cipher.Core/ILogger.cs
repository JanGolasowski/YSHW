using System;

namespace Cipher.Core
{
    public interface ILogger
    {
        void Error(string message);
        void Error(Exception ex, string message);
    }
}