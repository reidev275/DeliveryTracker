using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IPasswordHasher
    {
        User Hash(User user);
        bool IsValid(User user);
    }
}
