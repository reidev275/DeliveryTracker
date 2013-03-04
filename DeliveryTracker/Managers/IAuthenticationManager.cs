using DeliveryTracker.Models;

namespace DeliveryTracker.Managers
{
    public interface IAuthenticationManager
    {
        string Authenticate(Authentication authentication);
        AuthenticationResponse GetAuthentication(string code);
    }
}
