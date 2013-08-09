using DeliveryTracker.Managers;
using System;
using System.Net.Http;

namespace DeliveryTracker.Filters
{
	public class UserAuthRequiredAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
	{
		static IAuthenticationManager _manager = App_Start.NinjectWebCommon.Resolve<IAuthenticationManager>();

		public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
		{
			base.OnAuthorization(actionContext);
			var auth = actionContext.Request.Headers.GetValue("UserAuth");
			if (String.IsNullOrEmpty(auth)) actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException());

			if (!_manager.CodeIsValid(auth)) actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, new UnauthorizedAccessException("Your user is not authorized."));

			_manager.ExtendExpiration(auth);
		}
	}
}