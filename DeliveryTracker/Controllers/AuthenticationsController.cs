using System;
using System.Web.Http;
using DeliveryTracker.Models;

namespace DeliveryTracker.Controllers
{
	public class AuthenticationsController : ApiController
	{
		// GET api/authentications/5
		public string Get(string id)
		{
			return "value";
		}

		// POST api/authentications
		public string Post([FromBody]Authentication value)
		{
			throw new NotImplementedException();
		}
	}
}
