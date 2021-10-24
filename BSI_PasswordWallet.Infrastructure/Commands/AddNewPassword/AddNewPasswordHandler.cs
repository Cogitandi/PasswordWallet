using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            var passwordCore = new Password(command.User, command.Login, AesEncryptor.EncryptAES(command.Password, command.User.PasswordHash), command.WebAddress, command.Description);
            await _passwordRepository.AddPasswordAsync(passwordCore);
            // Decrypt the bytes to a string.
            //string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
        }
    }
}
