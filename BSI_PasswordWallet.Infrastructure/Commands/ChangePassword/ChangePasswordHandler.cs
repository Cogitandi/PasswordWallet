using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Encryption;
using BSI_PasswordWallet.Infrastructure.Settings;
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
        private readonly IPasswordRepository _passwordRepository;
        private readonly EncryptionSettings _encryptionSettings;

        public ChangePasswordHandler(IUserRepository userRepository, IPasswordRepository passwordRepository, EncryptionSettings encryptionSettings)
        {
            _userRepository = userRepository;
            _passwordRepository = passwordRepository;
            _encryptionSettings = encryptionSettings;
        }

        public async Task HandleAsync(ChangePasswordCommand command)
        {
            string pepper = _encryptionSettings.Pepper;
            User user = command.User;
            var currentUserPasswordHash = user.PasswordHash;
            var enteredOldPasswordHash = EncryptionManager.GeneratePasswordHash(user.IsPasswordKeptAsSHA512, command.OldPassword, user.Salt, pepper);
            if(currentUserPasswordHash != enteredOldPasswordHash)
            {
                throw new Exception("Entered password is incorrect");
            }

            user.Salt = EncryptionManager.GenerateSalt();
            var enteredNewPasswordHash = EncryptionManager.GeneratePasswordHash(user.IsPasswordKeptAsSHA512, command.NewPassword, user.Salt, pepper);
            IList<Password> userPasswords = await _passwordRepository.GetPasswordsAsync(user);
            user.PasswordHash = enteredNewPasswordHash;
            foreach (Password item in userPasswords)
            {
                string password = AesEncryptor.DecryptAES(item.PasswordValue, currentUserPasswordHash);
                item.PasswordValue = AesEncryptor.EncryptAES(password, enteredNewPasswordHash);
            }
            
            await _passwordRepository.UpdateAsync(userPasswords.ToArray());
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
