using System;

namespace Cipher.Core.Exceptions
{
    public class CipherException: Exception
    {
        public CipherException(string message) : base(message)
        {
        }
    }
}