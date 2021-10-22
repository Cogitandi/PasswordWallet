using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.CreateUser
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            var user = new User(command.Login, command.Password, true);
            await _userRepository.AddUserAsync(user);
        }
    }
}
