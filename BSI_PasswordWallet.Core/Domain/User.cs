using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public bool IsPasswordKeptAsSHA512 { get; set; }

        public User() { }

        public User(string login, string passwordHash, bool isPasswordKeptAsSHA512, string salt)
        {
            Login = login;
            PasswordHash = passwordHash;
            Salt = salt;
            IsPasswordKeptAsSHA512 = isPasswordKeptAsSHA512;
        }
    }
}
