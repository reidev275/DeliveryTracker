using DeliveryTracker.Models;
namespace DeliveryTracker.Repositories
{
    public interface IDeviceAuthRepository
    {
        bool CreateAuth(string auth);
        DeviceAuth GetDeviceAuth(string auth);
    }
}
