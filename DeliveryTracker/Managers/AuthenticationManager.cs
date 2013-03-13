using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;

namespace DeliveryTracker.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        readonly IAuthenticationsRepository _authentications;
        readonly IUsersRepository _users;
        readonly IPasswordHasher _hasher;

        public AuthenticationManager(IAuthenticationsRepository authentiations, IUsersRepository users, IPasswordHasher hasher)
        {
            if (authentiations == null) throw new ArgumentNullException("authentiations");
            if (users == null) throw new ArgumentNullException("users");
            if (hasher == null) throw new ArgumentNullException("hasher");
            _authentications = authentiations;
            _users = users;
            _hasher = hasher;
        }

        public string Authenticate(Authentication authentication)
        {
            if (authentication == null) throw new ArgumentNullException("authentiation");
            
            //User Exists?
            var user = _users.GetByUserName(authentication.UserName);
            if (user == null) return null;
            authentication.UserId = user.Id;

            //Password Matches?
            user.Password = authentication.Password;
            if (!_hasher.IsValid(user)) return null;

            var result = _authentications.Save(authentication);
            return result.Code;
        }

        public AuthenticationResponse GetAuthentication(string code)
        {
            if (!String.IsNullOrEmpty(code)) throw new ArgumentNullException("code");
            var authentication = _authentications.GetByCode(code);
            if (authentication == null) return null;

            var user = _users.GetById(authentication.UserId);
            if (user == null) return null;
            authentication.UserName = user.Name;
            return (AuthenticationResponse)authentication;
        }
    }
}