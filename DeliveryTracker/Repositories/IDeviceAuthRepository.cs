using DeliveryTracker.Models;
namespace DeliveryTracker.Repositories
{
    public interface IDeviceAuthRepository
    {
        bool Save(DeviceAuthRequest auth);
        DeviceAuth GetDeviceAuth(string auth);
    }
}
