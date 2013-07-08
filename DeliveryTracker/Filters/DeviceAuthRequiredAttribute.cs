using DeliveryTracker.Repositories;
using System;
using System.Net.Http;

namespace DeliveryTracker.Filters
{
    public class DeviceAuthRequiredAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        static IDeviceAuthRepository _repository = App_Start.NinjectWebCommon.Resolve<IDeviceAuthRepository>();

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var auth = actionContext.Request.Headers.GetValue("DeviceAuth");
            if (String.IsNullOrEmpty(auth)) actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException());
            var result = _repository.GetDeviceAuth(auth);
            if (result == null || !result.IsValid) actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException("Your device is not authorized."));
        }
    }
}