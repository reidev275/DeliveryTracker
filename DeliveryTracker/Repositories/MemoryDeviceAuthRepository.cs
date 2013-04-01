using DeliveryTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class MemoryDeviceAuthRepository : IDeviceAuthRepository
    {
        private static readonly List<DeviceAuthRequest> _repo = new List<DeviceAuthRequest>();

        public bool Save(DeviceAuthRequest auth)
        {
            _repo.Add(auth);
            return true;
        }

        public DeviceAuth GetDeviceAuth(string auth)
        {
            var deviceAuth = _repo.FirstOrDefault(x => x.AuthCode == auth);
            if (deviceAuth == null) return null;
            return new DeviceAuth
            {
                Code = deviceAuth.AuthCode,
                IsValid = true
            };
        }
    }
}