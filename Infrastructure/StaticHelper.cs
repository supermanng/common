using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Etechnosoft.Common.Infrastructure
{
    public class StaticHelper
    {
        public static string GetHash(string text, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text + salt));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string GetSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public static bool IsCorrect(string input, string salt, string text)
        {
            return GetHash(text, salt) == input;
        }
        public static string RandomNumbers(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
        }
        private static readonly Random RandomGenerator = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
        }
    }
}