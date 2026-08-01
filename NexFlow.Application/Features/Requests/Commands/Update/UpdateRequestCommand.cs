using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Features.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Update
{
    public sealed record UpdateRequestCommand(Guid Id,string Title, string Description) : ICommand<RequestDto>;
}
