using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliveryTracker.Models;
using DeliveryTracker.Filters;
using DeliveryTracker.QuerystringStrategies;

namespace DeliveryTracker.Controllers
{
    [DeviceAuthRequired]
	public class DeliveriesController : ApiController
	{
        readonly IEnumerable<IDeliveryQueryStrategy> _strategies;

        public DeliveriesController(IEnumerable<IDeliveryQueryStrategy> strategies)
        {
            if (strategies == null) throw new ArgumentNullException("strategies");
            _strategies = strategies;

        }

		// GET deliveries
		public IEnumerable<Delivery> Get()
		{
            foreach (var strategy in _strategies)
            {
                strategy.Apply(Request.RequestUri.Query);
            }
            

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
