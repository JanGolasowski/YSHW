using System;
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

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("a");
            
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Can_Decrypt_Single_Character()
        {
            const string expected = "a";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Decrypt(".-");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Character_Upper_Case()
        {
            const string expected = ".-";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("A");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Whitespace()
        {
            var expected = string.Empty;

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("     ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Whitespace()
        {
            var expected = string.Empty;

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Decrypt("     ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("hello");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word_With_Trailing_Space()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("hello ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Single_Word()
        {
            const string expected = "hello";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Decrypt(".... . .-.. .-.. ---");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Multiple_Words()
        {
            const string expected = ".... . .-.. .-.. --- / .-- --- .-. .-.. -.. / ..-. .-. --- -- / -.-. .. .--. .... . .-.";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("Hello world from cipher");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Decrypt_Multiple_Words()
        {
            const string expected = "hello world from cipher";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Decrypt(".... . .-.. .-.. --- / .-- --- .-. .-.. -.. / ..-. .-. --- -- / -.-. .. .--. .... . .-.");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Encrypt_Single_Word_With_Mixed_Casing()
        {
            const string expected = ".... . .-.. .-.. ---";

            ICipher cipher = new MorseCodeCipher();

            var actual = cipher.Encrypt("Hello");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Encrpyting_Unsupported_Character_Throws_Exception()
        {
            ICipher cipher = new MorseCodeCipher();
             cipher.Encrypt("`");
        }


        {
        }

        {
        }
    }
}
