namespace DeliveryTracker.Models
{
	public class User
	{
		public int Id { get; set; }
        public string Name { get; set; }
		public string Password { get; set; }
		public string HintQuestion { get; set; }
		public string HintAnswer { get; set; }
	}
}