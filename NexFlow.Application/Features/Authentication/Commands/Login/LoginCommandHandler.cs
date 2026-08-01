using NexFlow.Application.Abstractions.Cqrs;
using NexFlow.Application.Common.Authentication;
using NexFlow.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Authentication.Commands.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IIdentityService _identityService;

        public LoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _identityService.LoginAsync(new Common.Authentication.LoginRequest(request.Email, request.Password), cancellationToken);
            return new LoginResponse(token.AccessToken, token.ExpiresAt);
        }
    }
}
