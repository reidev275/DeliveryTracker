using DeliveryTracker.Models;

namespace DeliveryTracker.Managers
{
    public interface IUsersManager
    {
        bool Update(User user);
        bool Create(User user);
    }
}
