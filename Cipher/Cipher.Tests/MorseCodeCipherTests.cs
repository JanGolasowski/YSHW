using System.Linq;
using Cipher.Core;
using Cipher.Core.Ciphers;
using Cipher.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cipher.Tests
{
    [TestClass]
    public class MorseCodeCipherTests
    {
        [TestMethod]
        public void Can_Encrypt_Single_Character()
        {
            const string expected = ".-";

            ICipher cipher = CreateCipher();

            var actual = cipher.Encrypt("a");
            
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Can_Decrypt_Single_Character()
        {
            const string expected = "a";

            ICipher cipher = CreateCipher();

            var actual = cipher.Decrypt(".-");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Character_Upper_Case()
        {
            const string expected = ".-";

            ICipher cipher =CreateCipher();

            var actual = cipher.Encrypt("A");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Whitespace()
        {
            var expected = string.Empty;

            ICipher cipher = CreateCipher();

            var actual = cipher.Encrypt("     ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Whitespace()
        {
            var expected = string.Empty;

            ICipher cipher = CreateCipher();

            var actual = cipher.Decrypt("     ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher = CreateCipher();

            var actual = cipher.Encrypt("hello");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word_With_Trailing_Space()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher =CreateCipher();

            var actual = cipher.Encrypt("hello ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Single_Word()
        {
            const string expected = "hello";

            ICipher cipher = CreateCipher();

            var actual = cipher.Decrypt(".... . .-.. .-.. ---");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Multiple_Words()
        {
            const string expected = ".... . .-.. .-.. --- / .-- --- .-. .-.. -.. / ..-. .-. --- -- / -.-. .. .--. .... . .-.";

            ICipher cipher = CreateCipher();

            var actual = cipher.Encrypt("Hello world from cipher");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Multiple_Words()
        {
            const string expected = "hello world from cipher";

            ICipher cipher = CreateCipher();

            var actual = cipher.Decrypt(".... . .-.. .-.. --- / .-- --- .-. .-.. -.. / ..-. .-. --- -- / -.-. .. .--. .... . .-.");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word_With_Mixed_Casing()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher = CreateCipher();

            var actual = cipher.Encrypt("Hello");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(CipherException))]
        public void Encrypting_Unsupported_Character_Throws_Exception()
        {
            ICipher cipher =CreateCipher();
             cipher.Encrypt("`");
        }

        [TestMethod]
        [ExpectedException(typeof(CipherException))]
        public void Decrypting_Unsupported_Character_Throws_Exception()
        {
            ICipher cipher = CreateCipher();
            cipher.Decrypt("*");
        }

        [TestMethod]
        public void Decrypting_Encrypted_Input_Returns_Original_Input()
        {
            const string expected = "hello world from cipher";

            ICipher cipher = CreateCipher();
            var encrypted = cipher.Encrypt(expected);

            var decrypted = cipher.Decrypt(encrypted);

            Assert.AreEqual(expected, decrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(MaxInputLengthExceededException))]
        public void Cannot_Process_Input_That_Exceeds_Max_Length()
        {
            var input = string.Join("", Enumerable.Range(1, MorseCodeCipher.MAX_LENGTH_OF_INPUT + 1 ).Select(_ => "a"));

            ICipher cipher = CreateCipher();
             cipher.Encrypt(input);
        }

        private MorseCodeCipher CreateCipher()
        {
            return new MorseCodeCipher(new DebugLogger());
        }
    }
}
