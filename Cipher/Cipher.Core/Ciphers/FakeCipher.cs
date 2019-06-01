namespace Cipher.Core.Ciphers
{
    public class FakeCipher : ICipher
    {
        public FakeCipher(CipherType type)
        {
            Type = type;
        }

        public CipherType Type { get; }

        public string Encrypt(string input)
        {
            return $"Encrypted input \"{input}\" with {nameof(FakeCipher)} of type {Type}.";
        }

        public string Decrypt(string input)
        {
            return $"Decrypted input \"{input}\" with {nameof(FakeCipher)} of type {Type}.";
        }
    }
}