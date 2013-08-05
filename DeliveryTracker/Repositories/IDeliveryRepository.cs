using DeliveryTracker.Models;
using System.Collections.Generic;

namespace DeliveryTracker.Repositories
{
	public interface IDeliveryRepository
	{
		IEnumerable<Delivery> GetByTruck(int truck);
	}
}
