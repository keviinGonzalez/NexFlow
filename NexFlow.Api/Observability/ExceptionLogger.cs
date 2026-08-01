namespace NexFlow.Api.Observability
{
    public static class ExceptionLogger
    {
        public static void Log(ILogger logger, HttpContext context, Exception exception)
        {
            var level = ExceptionLogLevelResolver.Resolve(exception);
            var method = context.Request.Method;
            var path = context.Request.Path;
            var query = context.Request.QueryString.HasValue
                ? context.Request.QueryString.Value
                : string.Empty;
            var traceId = context.TraceIdentifier;
            var user = context.User.Identity?.IsAuthenticated == true
                ? context.User.Identity.Name
                : "Anonymous";
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var userAgent = context.Request.Headers.UserAgent.ToString();

            logger.Log(
                level,
                exception,
                """
            HTTP request failed.

            Method: {Method}
            Path: {Path}
            Query: {Query}
            TraceId: {TraceId}
            User: {User}
            IP: {Ip}
            UserAgent: {UserAgent}
            ExceptionType: {ExceptionType}
            """,
                method,
                path,
                query,
                traceId,
                user,
                ip,
                userAgent,
                exception.GetType().Name);
        }
    }
}
