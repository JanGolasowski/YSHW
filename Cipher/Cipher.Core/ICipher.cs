namespace Cipher.Core
{
    public interface ICipher
    {
        CipherType Type { get; }

        string Encrypt(string input);

        string Decrypt(string input);
    }
}