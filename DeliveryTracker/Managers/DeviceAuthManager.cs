using DeliveryTracker.Repositories;
using System;

namespace DeliveryTracker.Managers
{
    public class DeviceAuthManager : IDeviceAuthManager
    {
        readonly string _authCode;
        readonly IDeviceAuthRepository _repository;

        public DeviceAuthManager(string authCode, IDeviceAuthRepository repository)
        {
            if (String.IsNullOrEmpty(authCode)) throw new ArgumentException("authCode cannot be null or empty");
            if (repository == null) throw new ArgumentNullException("repository");

            _authCode = authCode;
            _repository = repository;
        }

        public string CreateDeviceAuth(string authCode)
        {
            if (authCode != _authCode) return null;
            var auth = Guid.NewGuid().ToString();
            var result = _repository.CreateAuth(auth);
            return result ? auth : null;
        }
    }
}