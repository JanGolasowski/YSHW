using System;
using System.Collections.Generic;
using System.Text;
using Cipher.Core.Exceptions;

namespace Cipher.Core.Ciphers
{
    public class MorseCodeCipher : ICipher
    {
        public const int MAX_LENGTH_OF_INPUT = 99999;

        private readonly ILogger _logger;

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

        public CipherType Type => CipherType.MorseCode;

        public MorseCodeCipher(ILogger logger)
        {
            _logger = logger;
        }

        public string Encrypt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            ValidateMaxLength(input);

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
                    _logger.Error($"Failed to encrypt character \"{character}\" with {nameof(MorseCodeCipher)}.{Environment.NewLine}Original input was {input}.");
                    
                    throw new CipherException("Failed to encrypt input.");
                }
            }

            return builder.ToString().TrimEnd();
        }

        public string Decrypt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            ValidateMaxLength(input);

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
                    _logger.Error($"Failed to decrypt code \"{code}\" with {nameof(MorseCodeCipher)}.{Environment.NewLine}Original input was {input}.");
                    
                    throw new CipherException("Failed to decrypt input.");
                }
            }

            return builder.ToString();
        }

        private void ValidateMaxLength(string input)
        {
            if (input.Length > MAX_LENGTH_OF_INPUT)
            {
                throw new  MaxInputLengthExceededException(MAX_LENGTH_OF_INPUT);
            }
        }
    }
}