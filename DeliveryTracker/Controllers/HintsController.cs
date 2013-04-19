using DeliveryTracker.Repositories;
using System;
using System.Net;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
    public class HintsController : ApiController
    {
        readonly IUsersRepository _repository;
        public HintsController(IUsersRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        public string Get(string id)
        {
            if (String.IsNullOrEmpty(id)) throw new ArgumentException("id cannot be null or empty");
            var user = _repository.GetByUserName(id);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return user.HintQuestion;
        }
    }
}
