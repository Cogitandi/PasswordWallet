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
        public bool IsPasswordKeptAsHash { get; set; }

        public User() { }

        public User(string login, string password, bool isPasswordKeptAsHash)
        {
            Login = login;
            PasswordHash = password;
            Salt = User.GenerateSalt();
            IsPasswordKeptAsHash = isPasswordKeptAsHash;
        }
        public string GetPasswordHash(string rawPassword)
        {
            return rawPassword;
        }
        public string GetUserPassword()
        {
            return PasswordHash;
        }
        public static byte[] SHA512(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            Sha512Digest digester = new Org.BouncyCastle.Crypto.Digests.Sha512Digest();
            byte[] retValue = new byte[digester.GetDigestSize()];
            digester.BlockUpdate(bytes, 0, bytes.Length);
            digester.DoFinal(retValue, 0);
            return retValue;
        }
        public static byte[] HmacSha512(string text, string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            var hmac = new Org.BouncyCastle.Crypto.Macs.HMac(new Org.BouncyCastle.Crypto.Digests.Sha512Digest());
            hmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(System.Text.Encoding.UTF8.GetBytes(key)));

            byte[] result = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(result, 0);

            return result;
        }
        public static string GenerateSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
