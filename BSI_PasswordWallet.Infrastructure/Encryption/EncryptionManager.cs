using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Encryption
{
    public static class EncryptionManager
    {

        public static string SHA512(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            Sha512Digest digester = new Org.BouncyCastle.Crypto.Digests.Sha512Digest();
            byte[] retValue = new byte[digester.GetDigestSize()];
            digester.BlockUpdate(bytes, 0, bytes.Length);
            digester.DoFinal(retValue, 0);
            return Convert.ToBase64String(retValue);
        }
        public static string HmacSha512(string text, string key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            var hmac = new Org.BouncyCastle.Crypto.Macs.HMac(new Org.BouncyCastle.Crypto.Digests.Sha512Digest());
            hmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(System.Text.Encoding.UTF8.GetBytes(key)));

            byte[] result = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(result, 0);

            return Convert.ToBase64String(result);
        }
        private static string GenerateSHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
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
        public static bool isPasswordOk(User user, string password, string pepper)
        {
            string CheckedPasswordHash;
            if (user.IsPasswordKeptAsSHA512)
            {
                string SHA512Hash = GenerateSHA512(password);
                CheckedPasswordHash = user.Salt + SHA512Hash + pepper;
            }
            else
            {
                CheckedPasswordHash = HmacSha512(password,user.Salt);
            }
            return user.PasswordHash == CheckedPasswordHash;
        }
        public static string GeneratePasswordHash(bool SHA512, string password, string salt, string pepper)
        {
            string passwordHash;
            if (SHA512)
            {
                string SHA512Hash = GenerateSHA512(password);
                passwordHash = salt + SHA512Hash + pepper;
            }
            else
            {
                passwordHash = HmacSha512(password, salt);
            }
            return passwordHash;
        }
    }
}
