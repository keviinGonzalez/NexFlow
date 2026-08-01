using Microsoft.AspNetCore.Mvc;

namespace NexFlow.Api.Exceptions
{
    public sealed class ExceptionMappingResult
    {
        public int StatusCode { get; init; }

        public object Response { get; init; } = default!;
    }
}
