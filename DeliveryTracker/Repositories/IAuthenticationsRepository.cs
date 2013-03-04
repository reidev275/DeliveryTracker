using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IAuthenticationsRepository
    {
        AuthenticationResponse Save(Authentication authentication);
        AuthenticationResponse GetByCode(string authCode);
        AuthenticationResponse GetByUserId(int userId);
    }
}
