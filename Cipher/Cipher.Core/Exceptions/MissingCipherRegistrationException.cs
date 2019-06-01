using System;

namespace Cipher.Core.Exceptions
{
    public class MissingCipherRegistrationException : Exception
    {
        public MissingCipherRegistrationException(CipherType type) : base($"Cipher of type {type}  was not registered into provider.")
        {

        }
    }
}