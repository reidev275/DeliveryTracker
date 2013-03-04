using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;

namespace DeliveryTracker.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        readonly IAuthenticationsRepository _authentications;
        readonly IUsersRepository _users;

        public AuthenticationManager(IAuthenticationsRepository authentiations, IUsersRepository users)
        {
            if (authentiations == null) throw new ArgumentNullException("authentiations");
            if (users == null) throw new ArgumentNullException("users");
            _authentications = authentiations;
            _users = users;
        }

        public string Authenticate(Authentication authentication)
        {
            if (authentication == null) throw new ArgumentNullException("authentiation");
            
            //User Exists?
            var user = _users.GetByUserName(authentication.UserName);
            if (user == null) return null;

            //Password Matches?
            if (user.Password != authentication.Password) return null;

            var result = _authentications.Save(authentication);
            return result.Code;
        }

        public AuthenticationResponse GetAuthentication(string code)
        {
            if (!String.IsNullOrEmpty(code)) throw new ArgumentNullException("code");
            return _authentications.GetByCode(code);
        }
    }
}