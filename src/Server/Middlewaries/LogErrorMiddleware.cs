using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Passwords.Server.Models;
using System.Text.Json;

namespace Passwords.Server.Middlewaries
{
    public class LogErrorMiddleware
    {
        private const string internalServerError = "Internal Server Error";
        private const string innerException = "Internal Server Error (Inner Exception)";
        private readonly RequestDelegate next;
        private readonly ILogger<LogErrorMiddleware> logger;

        public LogErrorMiddleware(RequestDelegate next, ILogger<LogErrorMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            logger.LogError(internalServerError, exception);
            if (exception is AggregateException aex && aex.InnerExceptions.Count > 0)
                foreach (Exception aexInnerException in aex.InnerExceptions)
                    logger.LogError(innerException, aexInnerException);


            var error = new Error(nameof(HttpStatusCode.InternalServerError), exception.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
