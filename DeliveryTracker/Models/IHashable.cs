namespace DeliveryTracker.Models
{
    public interface IHashable
    {
        string Salt { get; set; }
        string Hash { get; set; }
        string Password { get; set; }
    }
}
