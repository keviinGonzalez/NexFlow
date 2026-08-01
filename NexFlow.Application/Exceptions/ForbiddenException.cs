using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Exceptions
{
    public sealed class ForbiddenException : ApplicationException
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
