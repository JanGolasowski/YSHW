using System;

namespace Cipher.Core.Exceptions
{
    public class CipherAlreadyRegisteredException : Exception
    {
        public CipherAlreadyRegisteredException(CipherType type) : base($"Cipher of type {type} was already registered into provider.")
        {

        }
    }
}