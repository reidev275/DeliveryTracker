using DeliveryTracker.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DeliveryTracker.Repositories
{
    public class PasswordHasher : IPasswordHasher
    {
        public User Hash(User user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Hash = GetHash(user.Password, user.Salt);
            return user;
        }

        public bool IsValid(User user)
        {
            var hash = GetHash(user.Password, user.Salt);
            return hash == user.Hash;
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