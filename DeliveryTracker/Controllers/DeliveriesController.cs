﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliveryTracker.Models;

namespace DeliveryTracker.Controllers
{
	public class DeliveriesController : ApiController
	{
		// GET deliveries
		public IEnumerable<Delivery> Get(int truck)
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
