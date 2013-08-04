using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Managers
{
	public class DeliveryManager : IDeliveryManager
	{
		readonly IDeliveryRepository _deliveryRepository;

		public DeliveryManager(IDeliveryRepository deliveryRepository)
		{
			if (deliveryRepository == null) throw new ArgumentNullException("deliveryRepository");
			_deliveryRepository = deliveryRepository;
		}

		public Delivery Update(Delivery delivery)
		{

			throw new NotImplementedException();
		}

		public Delivery Insert(Delivery delivery)
		{

			throw new NotImplementedException();
		}

		public IEnumerable<Delivery> GetByTruck(int truck)
		{
			return _deliveryRepository.GetByTruck(truck);
		}
	}
}