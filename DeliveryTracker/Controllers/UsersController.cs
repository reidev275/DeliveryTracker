using System.Web.Http;
using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;

namespace DeliveryTracker.Controllers
{
	public class UsersController : ApiController
	{
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

		// GET api/users/5
		public string Get(string id)
		{
			//get user by id
			return "value";
		}

		// POST api/users
		public void Post([FromBody]User value)
		{
            if (value == null) throw new ArgumentNullException("value");
            _repository.Create(value);
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
