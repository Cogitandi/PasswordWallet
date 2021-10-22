using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Infrastructure.Commands;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected readonly ICommandDispatcher _dispatcher;

        protected BaseController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetService<IUserService>();
            _dispatcher = serviceProvider.GetService<ICommandDispatcher>();
        }
        protected async Task<User> GetUser()
        {
            var userLogin = this.User.Claims.SingleOrDefault(x => x.Type == "login").Value;
            var user = await _userService.GetUserAsync(new GetUserByLoginRequest() { Login = userLogin });
            return user;
        }

    }
}
