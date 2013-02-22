using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
	public class AuthenticationsController : ApiController
	{
        private readonly IAuthenticationsRepository _repository;

        public AuthenticationsController() : this(new MemoryAuthenticationsRepository()) { }

        public AuthenticationsController(IAuthenticationsRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this._repository = repository;
        }

		// GET api/authentications/5
        public AuthenticationResponse Get(string id)
		{
            if (id == null) throw new ArgumentNullException("id");
            var result = _repository.GetByCode(id);
            return result;
		}

		// POST api/authentications
		public string Post([FromBody]Authentication value)
		{
            if (value == null) throw new ArgumentNullException("value");
            var result = _repository.Save(value);
            return result.Code;
		}
	}
}
