using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryTracker.Repositories
{
	public interface IDeliveryRepository
	{
		IEnumerable<Delivery> GetByTruck(int truck);
	}
}
