using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace Project.Application.Common.Helper.PasswordHandle
{
    public class PasswordHandle
    {
        public static bool ComparePassword(string pass, string input)
        {
            var dbPassword = pass.Split("|");
            var realPassword = dbPassword[0];
            byte[] salt = Convert.FromBase64String(dbPassword[1]);
            string passInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            bool is_same = realPassword.Equals(passInput);
            return is_same;
        }
    }
}
