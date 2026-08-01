using NexFlow.Application.Abstractions.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NexFlow.Application.Features.Requests.Queries
{
    public sealed record GetRequestByIdQuery(Guid Id) : IQuery<RequestDto>;
}
