using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Common.Interfaces
{
    public interface ICurrentUser
    {
        Guid? UserId { get; }
        string Email { get; }
        string Name { get; }
        IReadOnlyCollection<string> Roles { get; }
        bool IsAuthenticated { get; }
    }
}
