using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace DeliveryTracker.Filters
{
    public class DeviceAuthRequiredAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var result = actionContext.Request.IsAuthorizedDevice();
            if (!result) throw new UnauthorizedAccessException();
        }
    }

    public static class ApiExtensions
    {
        private static readonly string DeviceKey = ConfigurationManager.AppSettings["deviceAuthKey"];

        public static bool IsAuthorizedDevice(this HttpRequestMessage request)
        {
            IEnumerable<string> enumerableHeader;
            request.Headers.TryGetValues("EmpireDevice", out enumerableHeader);
            if (enumerableHeader == null) return false;

            var list = enumerableHeader as IList<string> ?? enumerableHeader.ToList();
            if (list.Count == 0) return false;

            var csAuthString = list.First();
            return csAuthString == DeviceKey;
        }
    }
}