using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Update
{
    public sealed record UpdateRequestRequest(string Title, string Description);
}
