using System;

namespace DeliveryTracker.Models
{
	public class Authentication : AuthenticationResponse
	{
		public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
	}
}