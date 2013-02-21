using System.Web.Http;
using DeliveryTracker.Models;

namespace DeliveryTracker.Controllers
{
	public class UsersController : ApiController
	{
		// GET api/users/5
		public string Get(string id)
		{
			//get user by id
			return "value";
		}

		// POST api/users
		public void Post([FromBody]User value)
		{
			//create new user
		}

		// PUT api/users/5
		public void Put(string id, [FromBody]User value)
		{
			//update user
		}
	}
}
