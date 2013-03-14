using DeliveryTracker.Models;

namespace DeliveryTracker.Managers
{
    public interface IUsersManager
    {
        void Update(User user);
        bool Create(User user);
    }
}
