using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ExceptionMiddleware> _logger { get; }
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
            
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                httpContext.Response.ContentType="application/json";
                httpContext.Response.StatusCode=(int)StatusCodes.Status500InternalServerError;
                var response=_env.IsDevelopment() ?
                    new ApiExceptionResponse((int)StatusCodes.Status500InternalServerError,ex.Message,ex.StackTrace.ToString())
                    : new ApiErrorResponse((int)StatusCodes.Status500InternalServerError);
                  var jsonResponse= JsonSerializer.Serialize(response);
                  await httpContext.Response.WriteAsync(jsonResponse);  
            }
        }
    }
}