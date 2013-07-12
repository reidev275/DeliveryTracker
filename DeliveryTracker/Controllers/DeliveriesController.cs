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
        //readonly IEnumerable<IDeliveryQueryStrategy> _strategies;

        //public DeliveriesController(IEnumerable<IDeliveryQueryStrategy> strategies)
        //{
        //    if (strategies == null) throw new ArgumentNullException("strategies");
        //    _strategies = strategies;

        //}

		// GET deliveries
		public IEnumerable<Delivery> Get(int? truck = null)
		{
            //foreach (var strategy in _strategies)
            //{
            //    strategy.Apply(Request.RequestUri.Query);
            //}

            return new List<Delivery>
            {
                new Delivery
                {
                    Addr1 = "9302 Ashmeade Rd.",
                    Contact = "Clark Kent",
                    Truck = truck ?? 0,
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Number = "CTG43",
                            Description = "Countertop",
                            Allocated = 60,
                            Delivered = 60,
                            UnitOfMeasure = "IN"
                        }
                    }
                }
            };

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
	}
}
