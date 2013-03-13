using DeliveryTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
    public class TrucksController : ApiController
    {
        readonly ITrucksRepository _repository;
        public TrucksController(ITrucksRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        public IEnumerable<int> Get()
        {
            return _repository.GetAll();
        }
    }
}