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
        public string Hash { get; set; }

        public UserPassword(string hash)
        {
            Hash = hash;
        }
    }
}
