using Newtonsoft.Json;
using System.Net;

namespace SimpleStore.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) 
        { 
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); 
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while processing: {httpContext.Request.Path}");
                await HandleExceptionAsync(httpContext, ex); 
            } 
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails()
            {
                StatusCode = (int)statusCode,
                ErrorMessage = ex.Message,
                ErrorType = "Failure"
            };

            string response = JsonConvert.SerializeObject(errorDetails);
            httpContext.Response.StatusCode = (int)statusCode;
            return httpContext.Response.WriteAsync(response);
        }
    }


}
