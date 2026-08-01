using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Abstractions.Cqrs
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
