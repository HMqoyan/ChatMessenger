using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ChatMessenger.Common.Utilities
{
    public static class HashingUtilities
    {
        public static string GetHashSHA512(string str)
        {
            string hash;
            using (var sha512 = SHA512.Create())
            {
                byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(str));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return hash;
        }
    }
}
