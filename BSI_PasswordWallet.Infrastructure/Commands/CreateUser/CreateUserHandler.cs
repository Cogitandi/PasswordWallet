using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Encryption;
using BSI_PasswordWallet.Infrastructure.Services.UserService;
using BSI_PasswordWallet.Infrastructure.Settings;
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
        private readonly EncryptionSettings _encryptionSettings;

        public CreateUserHandler(IUserRepository userRepository, EncryptionSettings encryptionSettings)
        {
            _userRepository = userRepository;
            this._encryptionSettings = encryptionSettings;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            User userWithSameName = await _userRepository.GetUserAsync(command.Login);
            if (userWithSameName != null)
            {
                throw new Exception($"User {command.Login} already exist");
            }
            string salt = EncryptionManager.GenerateSalt();
            string pepper = _encryptionSettings.Pepper;
            string passwordHash = EncryptionManager.GeneratePasswordHash(command.IsPasswordKeptAsSHA512, command.Password, salt, pepper);
            var user = new User(command.Login, passwordHash, command.IsPasswordKeptAsSHA512, salt);
            await _userRepository.AddUserAsync(user);
        }
    }
}
