using NexFlow.Application.Abstractions.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Authentication.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;
}
