using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using DeliveryTracker.Repositories;
using Ninject;

namespace DeliveryTracker.Filters
{
    public class DeviceAuthRequiredAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        [Inject]
        public IDeviceAuthRepository AuthRepository { get; set; }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var auth = actionContext.Request.Headers.GetValue("DeviceAuth");
            if (String.IsNullOrEmpty(auth)) actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException());
            var result = AuthRepository.GetDeviceAuth(auth);
            if (!result.IsValid) actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException());
        }
    }

    public static class ApiExtensions
    {
        private static readonly string DeviceKey = ConfigurationManager.AppSettings["deviceAuthKey"];

        public static bool IsAuthorizedDevice(this HttpRequestMessage request)
        {
            var deviceHeader = request.Headers.GetValue("DeviceAuth");
            return deviceHeader == DeviceKey;
        }

        public static string GetValue(this System.Net.Http.Headers.HttpRequestHeaders obj, string key)
        {
            IEnumerable<string> enumerableHeader;
            obj.TryGetValues(key, out enumerableHeader);

            if (enumerableHeader == null) return null;

            var list = enumerableHeader as IList<string> ?? enumerableHeader.ToList();
            if (list.Count == 0) return null;

            return list.First();
        }
    }
}