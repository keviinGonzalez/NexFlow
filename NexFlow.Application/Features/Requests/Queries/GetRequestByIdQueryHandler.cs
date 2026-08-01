using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Abstractions.Persistence;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Queries
{
    public sealed class GetRequestByIdQueryHandler : IQueryHandler<GetRequestByIdQuery, RequestDto>
    {
        private readonly IRequestRepository _requestRepository;

        public GetRequestByIdQueryHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<RequestDto> Handle(GetRequestByIdQuery query, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetByIdAsync(query.Id, cancellationToken);

            if (request == null)
            {
                throw new Exception($"Request with ID {query.Id} not found.");
            }
            return new RequestDto(request.Id, request.Title, request.Description);
        }
    }
}
