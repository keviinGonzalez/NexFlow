using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexFlow.Application.Features.Request.Commands.CreateRequest;
using NexFlow.Application.Features.Requests.Commands.Create;
using NexFlow.Application.Features.Requests.Commands.Delete;
using NexFlow.Application.Features.Requests.Commands.Update;
using NexFlow.Application.Features.Requests.Queries;

namespace NexFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestsController : ControllerBase
    {
        private readonly ISender _sender;

        public RequestsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateRequestResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateRequestCommand command, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(command, cancellationToken);
            return Created(string.Empty, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetRequestByIdQuery(id);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(RequestDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRequestRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateRequestCommand(id, request.Title, request.Description);
            var response = await _sender.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(DeleteRequestResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteRequestCommand(id);
            var response = await _sender.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
