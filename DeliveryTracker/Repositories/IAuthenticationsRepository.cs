using DeliveryTracker.Models;
using System;

namespace DeliveryTracker.Repositories
{
	public interface IAuthenticationsRepository
	{
		AuthenticationResponse Save(Authentication authentication);
		Authentication GetByCode(string authCode);
		void SetUpdated(string authCode, DateTime date);
	}
}
