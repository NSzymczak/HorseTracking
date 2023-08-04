using System;
using System.Security.Cryptography;

namespace HorseTrackingDesktop.Services.Hasher
{
    public class Hasher : IHasher
    {
        private byte[] MakeSalt()
        {
            var bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        private byte[] MakeHash(string password, byte[] salt)
        {
            using (var bytes = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA256))
            {
                return bytes.GetBytes(32);
            }
        }

        public string[] HashPassword(string password)
        {
            var salt = MakeSalt();
            var hashPassword = MakeHash(password, salt);

            return new string[] { Convert.ToBase64String(hashPassword), Convert.ToBase64String(salt) };
        }

        public bool CheckPassword(string password, string hash, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var hashedPassword = Convert.ToBase64String(MakeHash(password, saltBytes));
            return hashedPassword == hash;
        }
    }
}