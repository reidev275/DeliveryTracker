using DeliveryTracker.Models;

namespace DeliveryTracker.Repositories
{
    public interface IAuthenticationsRepository
    {
        AuthenticationResponse Save(Authentication authentication);
        Authentication GetByCode(string authCode);
    }
}
