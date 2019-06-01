using System.Linq;
using Cipher.Core;
using Cipher.Core.Ciphers;
using Cipher.Core.Exceptions;
using Cipher.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cipher.Tests
{
    [TestClass]
    public class CipherProviderTests
    {
        [TestMethod]
        public void StaticCipherProvider_With_MorseCode_CipherType_Registered_Returns_MorseCode_CipherType()
        {
            var expected = CipherType.MorseCode;

            var staticCipherProvider = new StaticCipherProvider();
            staticCipherProvider.RegisterCipher(new FakeCipher(CipherType.MorseCode));

            ICipherProvider provider = staticCipherProvider;
            var actual = provider.GetAvailableCiphers().ToList();

            Assert.AreEqual(actual.Count, 1);
            Assert.AreEqual(expected, actual.First());
        }

        [TestMethod]
        public void StaticCipherProvider_With_MorceCodeCipherRegistered_Returns_MorceCodeCipher()
        {
            var expected = CipherType.MorseCode;

            var staticCipherProvider = new StaticCipherProvider();
            staticCipherProvider.RegisterCipher(new MorseCodeCipher(new DebugLogger()));

            ICipherProvider provider = staticCipherProvider;
            var actual = provider.GetCipher(CipherType.MorseCode);
            
            Assert.AreEqual(expected, actual.Type);
        }

        [TestMethod]
        public void StaticCipherProvider_With_MorseCode_And_Caesar_Registered_Returns_Both()
        {
            var morseCodeCipherType = CipherType.MorseCode;
            var caesarCipherType = CipherType.Caesar;

            var staticCipherProvider = new StaticCipherProvider();
            staticCipherProvider.RegisterCipher(new FakeCipher(CipherType.MorseCode));
            staticCipherProvider.RegisterCipher(new FakeCipher(CipherType.Caesar));

            ICipherProvider provider = staticCipherProvider;
            var actual = provider.GetAvailableCiphers().ToList();

            Assert.AreEqual(actual.Count, 2);
            Assert.AreEqual(morseCodeCipherType, actual.First());
            Assert.AreEqual(caesarCipherType, actual.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(CipherAlreadyRegisteredException))]
        public void StaticCipherProvider_Cannot_Register_Same_CipherType_More_Than_Once()
        {
            var staticCipherProvider = new StaticCipherProvider();
            staticCipherProvider.RegisterCipher(new FakeCipher(CipherType.MorseCode));
            staticCipherProvider.RegisterCipher(new  FakeCipher(CipherType.MorseCode));
        }

        [TestMethod]
        [ExpectedException(typeof(MissingCipherRegistrationException))]
        public void StaticCipherProvider_Cannot_Get_Unregistered_CipherType()
        {
            var staticCipherProvider = new StaticCipherProvider();

            staticCipherProvider.GetCipher(CipherType.MorseCode);
        }
    }
}
