using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.CreateUser
{
    class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRepository _passwordRepository;

        public CreateUserHandler(IUserRepository userRepository, IPasswordRepository passwordRepository)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            var user = new User(command.Login, command.Password, true);
            await _userRepository.AddUserAsync(user);

            return;
        }
    }
}
