using Microsoft.AspNetCore.Identity;
using NexFlow.Application.Common.Authentication;
using NexFlow.Application.Common.Interfaces;
using NexFlow.Application.Exceptions;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Infrastructure.Identity
{
    public sealed class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public IdentityService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<JwtToken> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await ValidateUserAsync(request);

            var tokenUser = await CreateTokenUserAsync(user);

            var token = _tokenService.GenerateTokenAsync(tokenUser);

            await UpdateLastLoginAsync(user);

            return token;
        }

        private async Task<ApplicationUser> ValidateUserAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            if (!user.IsEnabled)
            {
                throw new UnauthorizedException("User account is disabled.");
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            return user;
        }

        private async Task<TokenUser> CreateTokenUserAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new TokenUser(user.Id, user.Email!, user.FullName, roles);
        }

        private async Task UpdateLastLoginAsync(ApplicationUser user)
        {
            user.UpdateLastLogin();
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new DomainException("Unable to update last login date.");
            }
        }
    }
}
