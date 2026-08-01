using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginResponse(string AccessToken, DateTime ExpireAt);
}
