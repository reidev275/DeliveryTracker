namespace DeliveryTracker.Models
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string Code { get; set; }
        public int Truck { get; set; }
    }
}