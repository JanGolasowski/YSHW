using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cipher.Core;
using Cipher.Web.Models;

namespace Cipher.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICipherProvider _cipherProvider;
        private readonly ILogger _logger;

        public HomeController(ICipherProvider cipherProvider, ILogger logger)
        {
            _cipherProvider = cipherProvider;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var ciphers = _cipherProvider.GetAvailableCiphers();
            var model = new CipherInputModel
                        {
                            CipherTypes = GetSelectListItemsForCiphers(ciphers)
                        };

            return View(model);
        }

        public ActionResult Process(CipherInputModel model)
        {
            try
            {
                var cipher = _cipherProvider.GetCipher(model.SelectedCipherType);
                var ciphers = _cipherProvider.GetAvailableCiphers();
                model.CipherTypes = GetSelectListItemsForCiphers(ciphers);

                var output = model.Mode == CipherMode.Encrypt
                    ? cipher.Encrypt(model.Input)
                    : cipher.Decrypt(model.Input);

                model.Output = output;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to process input.");
                model.Output = "Failed to process input.";
            }

            return View("Index", model);
        }

        private IEnumerable<SelectListItem> GetSelectListItemsForCiphers(IEnumerable<CipherType> ciphers)
        {
            return ciphers.Select(c => new SelectListItem
                                       {
                                           Text = c.ToString(),
                                           Value = c.ToString()
                                       });
        }
    }
}