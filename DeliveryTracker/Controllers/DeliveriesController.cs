using DeliveryTracker.Filters;
using DeliveryTracker.Managers;
using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
	[DeviceAuthRequired]
	[UserAuthRequired]
	public class DeliveriesController : ApiController
	{
		readonly IDeliveryManager _manager;

		public DeliveriesController(IDeliveryManager manager)
		{
			if (manager == null) throw new ArgumentNullException("manager");
			_manager = manager;
		}
		
		public IEnumerable<Delivery> Get(int? truck = null)
		{
			if (truck.HasValue) return _manager.GetByTruck(truck.Value);

			throw new HttpResponseException(HttpStatusCode.NotImplemented);
		}

		public HttpResponseMessage Post([FromBody]Delivery value)
		{
			var result = _manager.Insert(value);
			return new HttpResponseMessage(HttpStatusCode.Created);
		}

		public HttpResponseMessage Put(string id, [FromBody]Delivery value)
		{
			var result = _manager.Update(value);
			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
