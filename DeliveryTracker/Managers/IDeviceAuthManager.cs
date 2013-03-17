using DeliveryTracker.Models;
namespace DeliveryTracker.Managers
{
    public interface IDeviceAuthManager
    {
        string CreateDeviceAuth(DeviceAuthRequest authCode);
    }
}
