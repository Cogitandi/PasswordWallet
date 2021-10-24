using BSI_PasswordWallet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands.AddNewPassword
{
    public class AddNewPasswordCommand : ICommand
    {
        public User User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }
        
    }
}
