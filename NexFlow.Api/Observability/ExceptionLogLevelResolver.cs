using NexFlow.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace NexFlow.Api.Observability
{
    public static class ExceptionLogLevelResolver
    {
        public static LogLevel Resolve(Exception exception)
        {
            return exception switch
            {
                ValidationException => LogLevel.Warning,
                DomainException => LogLevel.Warning,
                UnauthorizedAccessException => LogLevel.Warning,
                _ => LogLevel.Error
            };
        }
    }
}
