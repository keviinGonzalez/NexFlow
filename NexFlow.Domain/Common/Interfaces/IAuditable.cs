using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common.Interfaces
{
    public interface IAuditable
    {
        DateTimeOffset CreatedAt { get; }
        DateTimeOffset? UpdatedAt { get; }
    }
}
