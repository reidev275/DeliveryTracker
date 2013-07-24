using DeliveryTracker.Filters;
using DeliveryTracker.Managers;
using DeliveryTracker.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
	[DeviceAuthRequired]
	public class UsersController : ApiController
	{
		private readonly IUsersManager _manager;

		public UsersController(IUsersManager manager)
		{
			if (manager == null) throw new ArgumentNullException("repository");
			_manager = manager;
		}

		// POST api/users
		public HttpResponseMessage Post([FromBody]User value)
		{
			if (value == null) throw new ArgumentNullException("value");

			var created = _manager.Create(value);
			return created ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateResponse(HttpStatusCode.Conflict);
		}

		// PUT /users/5
		public bool Put(string id, [FromBody]User value)
		{
			if (id == null) throw new ArgumentNullException("id");
			if (value == null) throw new ArgumentNullException("value");

			var updated = _manager.Update(value);
			if (!updated) throw new HttpResponseException(HttpStatusCode.Unauthorized);
			return true;
		}
	}
}
