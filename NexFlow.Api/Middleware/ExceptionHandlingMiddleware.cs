using Microsoft.AspNetCore.Mvc;
using NexFlow.Api.Exceptions;
using NexFlow.Api.Observability;
using Rollbar;
using System.Text.Json;

namespace NexFlow.Api.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception exception)
            {
                ExceptionLogger.Log(_logger, context, exception);

                //RollbarLocator.RollbarInstance.Error(exception);
                RollbarLocator.RollbarInstance.Error(
                exception,
                new Dictionary<string, object?>
                {
                    ["TraceId"] = context.TraceIdentifier,
                    ["Path"] = context.Request.Path.ToString(),
                    ["Method"] = context.Request.Method
                });

                var result = ExceptionMapper.Map(exception);

                if (result.Response is ProblemDetails problemDetails)
                {
                    problemDetails.Instance = context.Request.Path;
                    problemDetails.Extensions["traceId"] = context.TraceIdentifier;
                }

                context.Response.StatusCode = result.StatusCode;
                context.Response.ContentType = "application/problem+json";
                await context.Response.WriteAsJsonAsync(result.Response);
            }
        }
    }
}
