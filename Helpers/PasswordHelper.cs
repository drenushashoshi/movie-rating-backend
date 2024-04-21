using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;
using System.Text;

namespace movie_rating_backend.Helpers
{
    public class PasswordHelper
    {

        public static string HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] saltBytes = new byte[32];
                rng.GetBytes(saltBytes);
                string salt = Convert.ToBase64String(saltBytes);
                string hashedPassword = GetHashedPassword(password, salt);
                return $"{hashedPassword}:{salt}";
            }
        }
        private static string GetHashedPassword(string password, string salt)
        {
            using(var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }


        public static bool VerifyPassword(string password, string hashedPasswordWihtSalt)
        {
            string[] hash_salt = hashedPasswordWihtSalt.Split(':');
            if(hash_salt.Length != 2 )
            {
                throw new ArgumentException("Invalid hashed password with salt format");

            }

            string storedHashedPassword = hash_salt[0];
            string storedSalt = hash_salt[1];

            string computedHash = GetHashedPassword(password, storedSalt);

            return computedHash == storedHashedPassword;
        }
         
    }

}
