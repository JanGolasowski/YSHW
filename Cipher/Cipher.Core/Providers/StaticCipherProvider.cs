using System.Collections.Generic;
using Cipher.Core.Exceptions;

namespace Cipher.Core.Providers
{
    public class StaticCipherProvider : ICipherProvider
    {
        private readonly IDictionary<CipherType, ICipher> _ciphers = new Dictionary<CipherType, ICipher>();

        internal StaticCipherProvider()
        {

        }

        public StaticCipherProvider(IEnumerable<ICipher> ciphers)
        {
            foreach (var cipher in ciphers)
            {
                RegisterCipher(cipher);
            }
        }
        
        internal void RegisterCipher(ICipher cipher)
        {
            var type = cipher.Type;

            if (_ciphers.ContainsKey(type))
            {
                throw new  CipherAlreadyRegisteredException(type);
            }

            _ciphers.Add(type, cipher);
        }

        public IEnumerable<CipherType> GetAvailableCiphers()
        {
            return _ciphers.Keys;
        }

        public ICipher GetCipher(CipherType type)
        {
            if (!_ciphers.TryGetValue(type, out var cipher))
            {
                throw new MissingCipherRegistrationException(type);
            }

            return cipher;
        }
    }
}