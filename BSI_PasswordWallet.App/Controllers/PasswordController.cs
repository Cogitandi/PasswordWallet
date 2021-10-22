using BSI_PasswordWallet.Infrastructure.Commands.AddNewPassword;
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

        public async Task<IActionResult> ViewPasswords()
        {
            var user = await GetUser();
            var response = await _passwordService.GetUserPasswords(user);
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
            return RedirectToAction("ViewPasswords");
        }
    }
}
