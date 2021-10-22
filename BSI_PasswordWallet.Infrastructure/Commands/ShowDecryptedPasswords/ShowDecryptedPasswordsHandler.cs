using BSI_PasswordWallet.Infrastructure.MVC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.ShowDecryptedPasswords
{
    public class ShowDecryptedPasswordsHandler : ICommandHandler<ShowDecryptedPasswordsCommand>
    {
        private readonly HttpContext _httpContext;

        public ShowDecryptedPasswordsHandler(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContext = httpContextAccessor.HttpContext;
        }

        public async Task HandleAsync(ShowDecryptedPasswordsCommand command)
        {
            var userPasswordHash = command.User.PasswordHash;
            var enteredPasswordHash = command.User.GetPasswordHash(command.Password);

            if(userPasswordHash != enteredPasswordHash)
            {
                throw new Exception("You passed wrong password");
            }

            var accessToken = JWTToken.GenerateJSONWebToken(command.User.Login,true);
            _httpContext.Session.SetString("Token", accessToken);
            await Task.CompletedTask;
        }
    }
}
