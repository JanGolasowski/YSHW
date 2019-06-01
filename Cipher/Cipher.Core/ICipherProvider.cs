using System.Collections.Generic;

namespace Cipher.Core
{
    public interface ICipherProvider
    {
        IEnumerable<CipherType> GetAvailableCiphers();

        ICipher GetCipher(CipherType type);
    }
}