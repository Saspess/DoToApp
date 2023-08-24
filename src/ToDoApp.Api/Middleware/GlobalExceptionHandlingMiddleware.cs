using System.Net;
using System.Text.Json;
using ToDoApp.Business.Exceptions;

namespace ToDoApp.Api.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException notFoundException)
            {
                var code = HttpStatusCode.NotFound;
                var message = notFoundException.Message;

                await HandleExceptionAsync(context, code, message);
            }
            catch (UserNotFoundException userNotFoundException)
            {
                var code = HttpStatusCode.NotFound;
                var message = userNotFoundException.Message;

                await HandleExceptionAsync(context, code, message);
            }
            catch (Exception exception)
            {
                var code = HttpStatusCode.InternalServerError;
                var message = exception.Message;

                await HandleExceptionAsync(context, code, message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
        {
            _logger.LogError(message);

            var result = JsonSerializer.Serialize(message);

            var httpResponse = context.Response;
            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = (int)code;

            await httpResponse.WriteAsync(result);
        }
    }
}
