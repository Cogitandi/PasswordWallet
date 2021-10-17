using BSI_PasswordWallet.App.Models;
using BSI_PasswordWallet.Infrastructure.Commands;
using BSI_PasswordWallet.Infrastructure.Commands.CreateUser;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, ICommandDispatcher dispatcher, IUserService userService)
        {
            _logger = logger;
            _dispatcher = dispatcher;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]CreateUserCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return Ok();
         }
        public async Task<IActionResult> GetUser()
        {
            var model = new GetUserByIdRequest()
            {
                Login = "login"
            };
            var result = await _userService.GetUserByIdAsync(model);
            return Ok(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
