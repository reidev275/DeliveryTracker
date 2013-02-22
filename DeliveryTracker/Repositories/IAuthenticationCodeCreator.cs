using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IAuthenticationCodeCreator
    {
        string CreateAuthenticationCode(Authentication authentication);
    }
}
