using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Abstractions.Cqrs
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
