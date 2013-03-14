using DeliveryTracker.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DeliveryTracker.Managers
{
    public class PasswordHasher : IPasswordHasher
    {
        public IHashable Hash(IHashable hashable)
        {
            hashable.Salt = Guid.NewGuid().ToString();
            hashable.Hash = GetHash(hashable.Password, hashable.Salt);
            return hashable;
        }

        public bool IsValid(IHashable hashable)
        {
            var hash = GetHash(hashable.Password, hashable.Salt);
            return hash == hashable.Hash;
        }

        string GetHash(string password, string salt)
        {
            byte[] byteRepresentation = UnicodeEncoding.UTF8.GetBytes(password + salt);

            byte[] hashedTextInBytes = null;

            var sha1 = new SHA1CryptoServiceProvider();
            hashedTextInBytes = sha1.ComputeHash(byteRepresentation);
            return Convert.ToBase64String(hashedTextInBytes);
        }
    }
}