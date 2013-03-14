using DeliveryTracker.Models;

namespace DeliveryTracker.Managers
{
    public interface IPasswordHasher
    {
        IHashable Hash(IHashable hashable);
        bool IsValid(IHashable hashable);
    }
}
