using Microsoft.AspNetCore.Http;
using NexFlow.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace NexFlow.Infrastructure.Authentication
{
    public sealed class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public Guid? UserId
        {
            get
            {
                var value = User?.FindFirstValue(ClaimTypes.NameIdentifier);
                return Guid.TryParse(value, out var id) ? id : null;
            }
        }

        public string? Email => User?.FindFirstValue(ClaimTypes.Email);


        public string? Name =>
            User?.FindFirstValue(ClaimTypes.Name);


        public IReadOnlyCollection<string> Roles =>
            User?
                .FindAll(ClaimTypes.Role)
                .Select(x => x.Value)
                .ToArray()
            ?? [];


        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;
    }
}
