using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightsManager.Utils
{
    public static class HashPassword
    {
        public static string GenerateSHA512(string pass, bool l = false)
        {
            string hashedPassword = "";
            try
            {
                byte[] passBytes = Encoding.UTF8.GetBytes(pass);
                using (SHA512 hash = new SHA512Managed())
                {
                    byte[] hashBytesArr = hash.ComputeHash(passBytes);
                    hashedPassword = BitConverter.ToString(hashBytesArr).Replace("-", "");
                }
                hashedPassword = (l ? hashedPassword.ToLowerInvariant() : hashedPassword);
            }
            catch
            {

            }
            return hashedPassword;
        }
    }
}