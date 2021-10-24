using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Commands.ChangePassword;
using BSI_PasswordWallet.Infrastructure.Commands.CreateUser;
using BSI_PasswordWallet.Infrastructure.Encryption;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.Settings;
using System;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptionSettings _encryptionSettings;

        public UserService(IUserRepository userRepository, EncryptionSettings encryptionSettings)
        {
            _userRepository = userRepository;
            _encryptionSettings = encryptionSettings;
        }

        public async Task<User> GetUserAsync(GetUserByLoginRequest model)
        {
            var core = await _userRepository.GetUserAsync(model.Login);

            return core;
        }

        public async Task<bool> IsCredentialsValidAsync(LoginRequest request)
        {
            User user = await _userRepository.GetUserAsync(request.Login);
            if(user==null)
            {
                throw new Exception("Incorrect credentials");
            }
            string pepper = _encryptionSettings.Pepper;
            string passwordHash = EncryptionManager.GeneratePasswordHash(user.IsPasswordKeptAsSHA512, request.Password, user.Salt, pepper);
            return user.PasswordHash == passwordHash;
        }
    }
}
