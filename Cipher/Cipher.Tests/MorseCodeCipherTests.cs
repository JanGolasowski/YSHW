using System;
using System.Collections.Generic;
using System.Text;
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
    }

    public interface ICipher
    {
        string Encrypt(string input);

        string Decrypt(string input);
    }

    public class MorseCodeCipher : ICipher
    {
        private readonly IDictionary<char, string> _encryptionMap = new Dictionary<char, string>
                                                     {
                                                         {'a', ".-"},
                                                         {'b', "	-..."},
                                                         {'c', "-.-."},
                                                         {'d', "-.."},
                                                         {'e', "."},
                                                         {'f', "..-."},
                                                         {'g', "--."},
                                                         {'h', "...."},
                                                         {'i', ".."},
                                                         {'j', ".---"},
                                                         {'k', "-.-"},
                                                         {'l', ".-.."},
                                                         {'m', "--"},
                                                         {'n', "-."},
                                                         {'o', "---"},
                                                         {'p', ".--."},
                                                         {'q', "--.-"},
                                                         {'r', ".-."},
                                                         {'s', "..."},
                                                         {'t', "-"},
                                                         {'u', "..-"},
                                                         {'v', "...-"},
                                                         {'w', ".--"},
                                                         {'x', "-..-"},
                                                         {'y', "-.--"},
                                                         {'z', "--.."},
                                                         {' ',"/" }
                                                     };

        private readonly IDictionary<string, char> _decryptionMap = new Dictionary<string, char>
                                                                    {
                                                                        {".-", 'a'},
                                                                        {"	-...", 'b'},
                                                                        {"-.-.", 'c'},
                                                                        {"-..", 'd'},
                                                                        {".", 'e'},
                                                                        {"..-.", 'f'},
                                                                        {"--.", 'g'},
                                                                        {"....", 'h'},
                                                                        {"..", 'i'},
                                                                        {".---", 'j'},
                                                                        {"-.-", 'k'},
                                                                        {".-..", 'l'},
                                                                        {"--", 'm'},
                                                                        {"-.", 'n'},
                                                                        {"---", 'o'},
                                                                        {".--.", 'p'},
                                                                        {"--.-", 'q'},
                                                                        {".-.", 'r'},
                                                                        {"...", 's'},
                                                                        {"-", 't'},
                                                                        {"..-", 'u'},
                                                                        {"...-", 'v'},
                                                                        {".--", 'w'},
                                                                        {"-..-", 'x'},
                                                                        {"-.--", 'y'},
                                                                        {"--..", 'z'},
                                                                        {"/",' '}
                                                                    };

        public string Encrypt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var builder = new StringBuilder();

            var characters = input
                .Trim()
                .ToLowerInvariant()
                .ToCharArray();

            foreach (var character in characters)
            {
                if (_encryptionMap.TryGetValue(character, out var code))
                {
                    builder.AppendFormat($"{code} ");
                }
                else
                {
                    //TODO custom exception and logging
                    throw new NotSupportedException();
                }
            }

            return builder.ToString().TrimEnd();
        }

        public string Decrypt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var builder = new StringBuilder();

            var codes = input.Split(' ');

            foreach (var code in codes)
            {
                if (_decryptionMap.TryGetValue(code, out var character))
                {
                    builder.Append(character);
                }
                else
                {
                    //TODO custom exception and logging
                    throw new NotSupportedException();
                }
            }

            return builder.ToString();
        }
    }
}
