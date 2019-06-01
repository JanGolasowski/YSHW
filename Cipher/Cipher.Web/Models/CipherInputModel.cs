using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Cipher.Core;

namespace Cipher.Web.Models
{
    public enum CipherMode
    {
        Encrypt,
        Decrypt
    }

    public class CipherInputModel
    {
        public IEnumerable<SelectListItem> CipherTypes { get; set; }

        [Display(Name = "Select cipher type")]
        public CipherType SelectedCipherType { get; set; }

        public CipherMode Mode { get; set; }

        [Required]
        public string Input { get; set; }

        public string Output { get; set; }

        
    }
}