using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Core.Domain
{
    public class Password
    {
        public Password()
        {

        }

        public Password(User user, string login, string passwordValue, string webAddress, string description)
        {
            User = user;
            Login = login;
            PasswordValue = passwordValue;
            WebAddress = webAddress;
            Description = description;
        }

        public Guid Id { get; set; }
        public User User { get; set; }
        public string Login { get; set; }
        public string PasswordValue { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }
    }
}
