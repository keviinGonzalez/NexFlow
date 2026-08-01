using NexFlow.Application.Abstractions.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NexFlow.Application.Features.Requests.Commands.Delete
{
    public sealed record DeleteRequestCommand(Guid Id) : ICommand<DeleteRequestResponse>;
}
