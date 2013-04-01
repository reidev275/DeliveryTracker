using DeliveryTracker.Models;
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

        public string CreateDeviceAuth(DeviceAuthRequest authCode)
        {
            if (authCode.AuthCode != _authCode) return null;
            authCode.AuthCode = Guid.NewGuid().ToString();
            var result = _repository.Save(authCode);
            return result ? authCode.AuthCode : null;
        }
    }
}