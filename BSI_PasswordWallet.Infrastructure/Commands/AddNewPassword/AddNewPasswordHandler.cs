using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.AddNewPassword
{
    public class AddNewPasswordHandler : ICommandHandler<AddNewPasswordCommand>
    {
        private readonly IPasswordRepository _passwordRepository;

        public AddNewPasswordHandler(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task HandleAsync(AddNewPasswordCommand command)
        {
            var passwordCore = new Password(command.Password, command.User, "", "", "");
            await _passwordRepository.AddPasswordAsync(passwordCore);
        }
    }
}
