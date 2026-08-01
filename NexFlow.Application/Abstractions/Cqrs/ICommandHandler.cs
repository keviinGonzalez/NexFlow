using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Abstractions.Cqrs
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}
