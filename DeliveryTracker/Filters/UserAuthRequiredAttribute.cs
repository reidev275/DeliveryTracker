using DeliveryTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DeliveryTracker.Filters
{
    public class UserAuthRequiredAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        static IAuthenticationsRepository _repository = App_Start.NinjectWebCommon.Resolve<IAuthenticationsRepository>();

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var auth = actionContext.Request.Headers.GetValue("UserAuth");
            if (String.IsNullOrEmpty(auth)) actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException());
            var result = _repository.GetByCode(auth);
            if (result == null || !result.IsValid) actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException("Your user is not authorized."));
        }
    }
}