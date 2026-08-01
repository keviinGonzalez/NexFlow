using NexFlow.Application.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtToken> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}
