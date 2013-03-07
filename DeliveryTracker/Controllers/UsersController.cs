using DeliveryTracker.Filters;
using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
    [DeviceAuthRequired]
	public class UsersController : ApiController
	{
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

		// POST api/users
        public HttpResponseMessage Post([FromBody]User value)
		{
            if (value == null) throw new ArgumentNullException("value");

            var created = _repository.Create(value);
            return created ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateResponse(HttpStatusCode.Conflict);
		}

		// PUT api/users/5
		public void Put(string id, [FromBody]User value)
		{
            if (id == null) throw new ArgumentNullException("id");
            if (value == null) throw new ArgumentNullException("value");

            _repository.Update(value);
		}
	}
}
