using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IUsersRepository
    {
        User GetByUserName(string userName);
        User GetById(int id);
        bool Update(User user);
        bool Create(User user);
    }
}
