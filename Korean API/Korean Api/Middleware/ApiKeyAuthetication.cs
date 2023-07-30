
using Korean_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
namespace Korean_Api.Middleware
{
    public class ApiKeyAuthetication : Attribute, IAuthorizationFilter
    {
    
      
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKey.ApiKeyHeaderName, out var key))
            {

                var error = new { message = "Api key is missing" };
                context.Result = new UnauthorizedObjectResult(error);
                return;

            }
            var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var ApiKeyfromHeader = context.HttpContext.Request.Headers[ApiKey.ApiKeyHeaderName];
            var ApiKeyInAppSetting = _configuration.GetValue<string>(ApiKey.ApiKeyInAppSettings);
            if (string.IsNullOrEmpty(ApiKeyfromHeader) || ApiKeyInAppSetting != ApiKeyfromHeader)
            {
                var err = new { message = "Invalid api key." };
                context.Result = new UnauthorizedObjectResult(err);
                return;
            }
        }
    }
}