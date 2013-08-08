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

		public Delivery Update(int id, Delivery delivery)
		{
			if (id != delivery.Id) return null;
			var old = _deliveryRepository.GetById(id);
			if (old == null) return null;
			Delivery result = null;

			if (!String.IsNullOrEmpty(delivery.Printed) && !String.IsNullOrEmpty(delivery.Signature))
				result = _deliveryRepository.Complete(delivery);

			return delivery;
		}

		public Delivery Insert(Delivery delivery)
		{
			return _deliveryRepository.Insert(delivery);			
		}

		public IEnumerable<Delivery> GetByTruck(int truck)
		{
			return _deliveryRepository.GetByTruck(truck);
		}
	}
}