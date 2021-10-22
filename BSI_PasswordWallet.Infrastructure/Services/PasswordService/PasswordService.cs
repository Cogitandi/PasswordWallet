using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Commands.AddNewPassword;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task<UserPasswordsResponse> GetUserPasswords(User user, bool returnDecrypted)
        {
            var model = new UserPasswordsResponse();
            var passwordsCore = await _passwordRepository.GetPasswordsAsync(user);
            if(returnDecrypted)
            {
                model.Passwords = passwordsCore.Select(x => new UserPassword(x.PasswordValue+" odkodowane")).ToList();
                model.ShowDecoded = true;
            } else
            {
                model.Passwords = passwordsCore.Select(x => new UserPassword(x.PasswordValue)).ToList();
                model.ShowDecoded = false;
            }
            
            return model;
        }
    }
}
