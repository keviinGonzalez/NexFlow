using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Abstractions.Persistence;
using NexFlow.Application.Features.Requests.Commands.Create;
using NexFlow.Domain.Exceptions;

namespace NexFlow.Application.Features.Request.Commands.CreateRequest;

public sealed class CreateRequestHandler : ICommandHandler<CreateRequestCommand, CreateRequestResponse>
{
    private readonly IRequestRepository _requestRepository;

    public CreateRequestHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<CreateRequestResponse> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
    {
        var exists = await _requestRepository.ExistsByTitleAsync(command.Title, cancellationToken);

        if (exists)
        {
            throw new Exception("A request with the same title already exists.");
        }

        var request = new Domain.Entities.Request(command.Title, command.Description);
        await _requestRepository.AddAsync(request, cancellationToken);
        return new CreateRequestResponse(request.Id);
    }
}