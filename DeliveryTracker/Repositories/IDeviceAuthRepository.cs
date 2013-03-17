using DeliveryTracker.Models;
namespace DeliveryTracker.Repositories
{
    public interface IDeviceAuthRepository
    {
        bool CreateAuth(DeviceAuthRequest auth);
        DeviceAuth GetDeviceAuth(string auth);
    }
}
