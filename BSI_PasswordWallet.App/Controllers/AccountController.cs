using BSI_PasswordWallet.Infrastructure.Commands.ChangePassword;
using BSI_PasswordWallet.Infrastructure.Commands.CreateUser;
using BSI_PasswordWallet.Infrastructure.MVC;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.App.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IActionResult> CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromForm]CreateUserCommand command)
        {
            try
            {
                await _dispatcher.DispatchAsync(command);
                TempData["message"] = "Konto zostało utworzone pomyślnie.";
                return RedirectToAction("Login", "Account");
            } catch(Exception e)
            {
                TempData["message"] = $"Błąd: {e.Message}";
            }
            return View();  
        }
        public async Task<IActionResult> Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            bool credentialsOk = await _userService.IsCredentialsValidAsync(request);

            if(credentialsOk)
            {
                var accessToken = JWTToken.GenerateJSONWebToken(request.Login);
                HttpContext.Session.SetString("Token", accessToken);
                TempData["message"] = "Zalogowano pomyślnie";
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            TempData["message"] = "Zostałeś wylogowany pomyślnie";
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordCommand command)
        {
            command.User = await GetUser();
            try
            {
                await _dispatcher.DispatchAsync(command);
                TempData["message"] = "Hasło zostało zmienione";
            } catch(Exception e)
            {
                TempData["message"] = $"Błąd: {e.Message}";
            }
            return View();
        }

    }
}
