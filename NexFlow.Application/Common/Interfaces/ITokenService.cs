using NexFlow.Application.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Common.Interfaces
{
    public interface ITokenService
    {
        JwtToken GenerateTokenAsync(TokenUser user);
    }
}
