using BSI_PasswordWallet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.ShowDecryptedPasswords
{
    public class ShowDecryptedPasswordsCommand : ICommand
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
