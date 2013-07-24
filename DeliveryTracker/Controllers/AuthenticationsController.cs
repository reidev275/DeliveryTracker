using DeliveryTracker.Filters;
using DeliveryTracker.Managers;
using DeliveryTracker.Models;
using System;
using System.Net;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
	[DeviceAuthRequired]
	public class AuthenticationsController : ApiController
	{
		private readonly IAuthenticationManager _manager;

		public AuthenticationsController(IAuthenticationManager manager)
		{
			if (manager == null) throw new ArgumentNullException("manager");
			_manager = manager;
		}

		// GET api/authentications/5
		public AuthenticationResponse Get(string id)
		{
			if (id == null) throw new ArgumentNullException("id");
			var result = _manager.GetAuthentication(id);
			if (result == null) throw new HttpResponseException(HttpStatusCode.NotFound);
			return result;
		}

		// POST api/authentications
		public string Post([FromBody]Authentication value)
		{
			if (value == null) throw new ArgumentNullException("value");

			var result = _manager.Authenticate(value);
			if (result == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);
			return result;
		}
	}
}
