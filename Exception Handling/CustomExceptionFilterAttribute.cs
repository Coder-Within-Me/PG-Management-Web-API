using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PGManagement.Controllers;
using PGManagement.Respository;
using System.Net;
using System.Web.Http.Filters;

namespace PGManagement.Exception_Handling
{
    public class CustomExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is BadHttpRequestException)
            {
                _logger.LogError("Bad request by user.");
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
