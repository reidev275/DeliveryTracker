namespace DeliveryTracker.Managers
{
    public interface IDeviceAuthManager
    {
        string CreateDeviceAuth(string authCode);
    }
}
