using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Common.Authentication
{
    public sealed record TokenUser(Guid Id, string Email, string FullName, IEnumerable<string> Roles);
}
