using BSI_PasswordWallet.Infrastructure.Commands.AddNewPassword;
using BSI_PasswordWallet.Infrastructure.Commands.ShowDecryptedPasswords;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.Services.PasswordService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.App.Controllers
{
    [Authorize]
    public class PasswordController : BaseController
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IServiceProvider serviceProvider, IPasswordService passwordService) : base(serviceProvider)
        {
            _passwordService = passwordService;
        }

        public async Task<IActionResult> DecryptPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DecryptPassword([FromForm] ShowDecryptedPasswordsCommand command)
        {
            command.User = await GetUser();
            try
            {
                await _dispatcher.DispatchAsync(command);
                TempData["message"] = "Hasła zostały pomyślnie odkodowane.";
                return RedirectToAction("ViewPasswords", "Password");
            }
            catch (Exception e)
            {
                TempData["message"] = $"Błąd: {e.Message}";
            }
            return View();
        }
        public async Task<IActionResult> ViewPasswords()
        {
            var user = await GetUser();
            var showDecrypted = Boolean.Parse(this.User.Claims.SingleOrDefault(x => x.Type == "showDecrypted").Value);
            var response = await _passwordService.GetUserPasswords(user,showDecrypted);
            return View(response);
        }
        public IActionResult AddNewPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewPassword([FromForm]AddNewPasswordCommand command)
        {
            command.User = await GetUser();
            await _dispatcher.DispatchAsync(command);
            TempData["message"] = "Dodano nowe hasło";
            return RedirectToAction("ViewPasswords");
        }
    }
}
