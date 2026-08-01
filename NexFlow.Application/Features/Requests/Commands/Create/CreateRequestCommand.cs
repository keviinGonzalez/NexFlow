using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Features.Requests.Commands.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Request.Commands.CreateRequest
{
    public sealed record CreateRequestCommand(string Title, string Description) : ICommand<CreateRequestResponse>;
}
