using DeliveryTracker.Managers;
using DeliveryTracker.Models;
using System;
using System.Net;
using System.Web.Http;

namespace DeliveryTracker.Controllers
{
    public class DeviceAuthenticationsController : ApiController
    {
        readonly IDeviceAuthManager _manager;
        public DeviceAuthenticationsController(IDeviceAuthManager manager)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            _manager = manager;
        }

        public string Post([FromBody]DeviceAuthRequest authCode)
        {
            if (authCode == null) throw new ArgumentException("authCode cannot be null or empty");
            var result = _manager.CreateDeviceAuth(authCode);
            if (result == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return result;
        }
    }
}
