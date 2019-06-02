using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cipher.Core;

namespace Cipher.Web.Models
{
    internal static class CipherTypeToSelectListMapper
    {
        public static IEnumerable<SelectListItem> GetSelectListItemsForCiphers(IEnumerable<CipherType> cipherTypes)
        {
            return cipherTypes.Select(c => new SelectListItem
                                           {
                                               Text = MapCipherTypeToDescription(c),
                                               Value = c.ToString()
                                           });
        }

        private static string MapCipherTypeToDescription(CipherType type)
        {
            switch (type)
            {
                case CipherType.MorseCode:
                    return "Morse code";
                case CipherType.Caesar:
                    return "Caesar";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}