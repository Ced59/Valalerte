using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ValAlerte.Tools
{
    public static class Crypto
    {
        public static string hashPassword(string Password)
        {
            byte[] raw = UTF8Encoding.UTF8.GetBytes(Password);

            byte[] hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = md5Hash.ComputeHash(raw);
            }

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sBuilder.Append(hash[i].ToString("x2"));


            return sBuilder.ToString();
        }
    }
}
