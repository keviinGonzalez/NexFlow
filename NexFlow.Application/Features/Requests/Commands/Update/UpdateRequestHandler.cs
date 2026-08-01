using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Abstractions.Persistence;
using NexFlow.Application.Features.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Update
{
    public sealed class UpdateRequestHandler : ICommandHandler<UpdateRequestCommand, RequestDto>
    {
        private readonly IRequestRepository _requestRepository;

        public UpdateRequestHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<RequestDto> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
        {
            var requestEntity = await _requestRepository.GetByIdAsync(command.Id, cancellationToken);
            
            if (requestEntity == null)
            {
                throw new Exception("Request not found.");
            }

            requestEntity.Update(command.Title, command.Description);
            await _requestRepository.UpdateAsync(requestEntity, cancellationToken);

            return new RequestDto(requestEntity.Id, requestEntity.Title, requestEntity.Description);
        }
    }
}
