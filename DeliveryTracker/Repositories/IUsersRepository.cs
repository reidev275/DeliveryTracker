using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IUsersRepository
    {
        User GetByUserName(string userName);
        void Update(User user);
        void Create(User user);
    }
}
