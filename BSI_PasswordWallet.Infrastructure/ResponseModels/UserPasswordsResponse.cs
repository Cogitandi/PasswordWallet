using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.ResponseModels
{
    public class UserPasswordsResponse
    {
        public bool ShowDecoded { get; set; }
        public List<UserPassword> Passwords { get; set; }
    }
    public class UserPassword
    {
        public UserPassword(string login, string password, string webAddress, string description)
        {
            Login = login;
            Password = password;
            WebAddress = webAddress;
            Description = description;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }

    }
}
