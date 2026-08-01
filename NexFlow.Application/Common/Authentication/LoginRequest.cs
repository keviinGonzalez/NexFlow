using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Common.Authentication
{
    public sealed record LoginRequest(string Email, string Password);
}
