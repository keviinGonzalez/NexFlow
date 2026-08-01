using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Exceptions
{
    public sealed class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
