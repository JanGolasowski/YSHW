namespace Cipher.Core.Exceptions
{
    public class MaxInputLengthExceededException : CipherException
    {
        public MaxInputLengthExceededException(int maxLength):base($"Cipher can process inputs with max length of {maxLength} characters.")
        {
            
        }
    }
}