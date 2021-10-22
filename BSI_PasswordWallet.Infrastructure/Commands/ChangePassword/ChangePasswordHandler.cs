using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.ChangePassword
{
    class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(ChangePasswordCommand command)
        {
            User user = command.User;
            var userPassword = user.PasswordHash;
            var enteredOldPassword = user.GetPasswordHash(command.OldPassword);
            if(userPassword != enteredOldPassword)
            {
                throw new Exception("Entered password is incorrect");
            }
            user.Salt = User.GenerateSalt();
            user.PasswordHash = command.NewPassword;

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
