using BSI_PasswordWallet.Core.Domain;
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
    public interface IPasswordService : IService
    {
        public Task<UserPasswordsResponse> GetUserPasswords(User user);
    }
}
