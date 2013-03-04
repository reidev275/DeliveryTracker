using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class MemoryAuthenticationsRepository : IAuthenticationsRepository
    {
        static readonly List<Authentication> _authentications = new List<Authentication>();

        public AuthenticationResponse Save(Authentication authentication)
        {
            authentication.Code = Guid.NewGuid().ToString();
            authentication.Created = DateTime.Now;
            authentication.Updated = DateTime.Now;
            _authentications.Add(authentication);
            return authentication;
        }

        public AuthenticationResponse GetByCode(string authCode)
        {
            if (authCode == null) throw new ArgumentNullException("authCode");
            var result = _authentications.FirstOrDefault(x => x.Code == authCode);
            if (result == null) return null;
            result.Updated = DateTime.Now;
            return result;
        }


        public AuthenticationResponse GetByUserId(int userId)
        {
            var result = _authentications.FirstOrDefault(x => x.UserId == userId);
            if (result == null) return null;
            result.Updated = DateTime.Now;
            return result;
        }
    }
}