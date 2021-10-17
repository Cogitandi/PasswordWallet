using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.RequestModel
{
    public class CreateAccountRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsPasswordKeptAsHash { get; set; }
    }
}
