using DeliveryTracker.Models;
using System.Collections.Generic;

namespace DeliveryTracker.Repositories
{
	public interface IDeliveryRepository
	{
		IEnumerable<Delivery> GetByTruck(int truck);
		Delivery GetById(int id);
		Delivery Complete(Delivery delivery);
		Delivery Insert(Delivery delivery);
	}
}
