using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Infrastructure.Encryption;
using BSI_PasswordWallet.Infrastructure.MVC;
using BSI_PasswordWallet.Infrastructure.Settings;
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
        private readonly EncryptionSettings _encryptionSettings;

        public ShowDecryptedPasswordsHandler(IHttpContextAccessor httpContextAccessor, EncryptionSettings encryptionSettings)
        {
            _httpContext = httpContextAccessor.HttpContext;
            this._encryptionSettings = encryptionSettings;
        }

        public async Task HandleAsync(ShowDecryptedPasswordsCommand command)
        {
            User user = command.User;
            string pepper = _encryptionSettings.Pepper;
            var currentPasswordHash = user.PasswordHash;
            var enteredPasswordHash = EncryptionManager.GeneratePasswordHash(user.IsPasswordKeptAsSHA512, command.Password, user.Salt, pepper);

            if (currentPasswordHash != enteredPasswordHash)
            {
                throw new Exception("You passed wrong password");
            }

            var accessToken = JWTToken.GenerateJSONWebToken(command.User.Login,true);
            _httpContext.Session.SetString("Token", accessToken);
            await Task.CompletedTask;
        }
    }
}
