using System.Security.Cryptography;
using System.Text;
namespace BazarCore.Utils.Security
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);

            // Combine the salt and hash into a single string for storage
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            byte[] hash = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static byte[] HashPasswordWithSalt(byte[] passwordBytes, byte[] salt)
        {
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
            Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Array.Copy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            using (var sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(saltedPassword);
            }
        }
    }
}
