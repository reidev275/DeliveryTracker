using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliveryTracker.Models;
using DeliveryTracker.Filters;

namespace DeliveryTracker.Controllers
{
    [DeviceAuthRequired]
	public class DeliveriesController : ApiController
	{
		// GET deliveries
		public IEnumerable<Delivery> Get(int truck = 0, bool delivered = false)
		{
			throw new NotImplementedException();
		}

		//// GET deliveries/O    1234
		//public Delivery Get(string id)
		//{
		//    throw new NotImplementedException();
		//}

		public void Post([FromBody]Delivery value)
		{

		}

		public void Put(string id, [FromBody]Delivery value)
		{

		}

		//public void Delete(string id)
		//{
		//    throw new NotImplementedException();
		//}
	}
}
