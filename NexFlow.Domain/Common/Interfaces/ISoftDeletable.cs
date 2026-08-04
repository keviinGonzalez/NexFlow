using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTimeOffset? DeletedAt { get; }
        void SoftDelete();
        void Restore();
    }
}
