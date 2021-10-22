using BSI_PasswordWallet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.ChangePassword
{
    public class ChangePasswordCommand : ICommand
    {
        public User User { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
