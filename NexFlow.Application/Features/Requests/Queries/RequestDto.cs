using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Queries
{
    public sealed record RequestDto(Guid Id, string Title, string Description);
}
