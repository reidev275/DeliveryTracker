using DeliveryTracker.Models;

namespace DeliveryTracker.Managers
{
    public interface IPasswordHasher
    {
        User Hash(User user);
        bool IsValid(User user);
    }
}
