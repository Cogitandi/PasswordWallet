﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool IsPasswordKeptAsHash { get; set; }

        public User() { }

        public User(string login, string password, bool isPasswordKeptAsHash)
        {
            Login = login;
            IsPasswordKeptAsHash = isPasswordKeptAsHash;
        }
    }
}
