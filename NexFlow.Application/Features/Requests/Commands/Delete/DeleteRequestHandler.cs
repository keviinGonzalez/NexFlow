using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Abstractions.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Delete
{
    public sealed class DeleteRequestHandler : ICommandHandler<DeleteRequestCommand, DeleteRequestResponse>
    {
        private readonly IRequestRepository _requestRepository;

        public DeleteRequestHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<DeleteRequestResponse> Handle(DeleteRequestCommand command, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetByIdAsync(command.Id, cancellationToken);
            if (request is null)
            {
                throw new Exception("Request not found.");
            }

            request.Delete();
            await _requestRepository.UpdateAsync(request, cancellationToken);
            return new DeleteRequestResponse("Request deleted successfully.");
        }
    }
}
