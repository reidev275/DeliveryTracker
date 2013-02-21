using System;
using System.Web.Http;
using DeliveryTracker.Models;

namespace DeliveryTracker.Controllers
{
	public class AuthenticationsController : ApiController
	{
        private readonly IAuthenticationsRepository _repository;
        private readonly IAuthenticationCodeCreator _codeCreator;

        public AuthenticationsController()
        {

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

    public interface IAuthenticationCodeCreator
    {
        string CreateAuthenticationCode(Authentication authentication);
    }

    public interface IAuthenticationsRepository
    {
        AuthenticationResponse Save(Authentication authentication);
        AuthenticationResponse GetByCode(string authCode);
    }


}
