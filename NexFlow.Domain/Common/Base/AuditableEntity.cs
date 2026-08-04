using NexFlow.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common.Base
{
    public abstract class AuditableEntity : BaseEntity, IAuditable
    {
        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }

        //protected AuditableEntity()
        //{
        //    CreatedAt = DateTimeOffset.UtcNow;
        //}

        //protected virtual void MarkAsUpdated()
        //{
        //    UpdatedAt = DateTimeOffset.UtcNow;
        //}
    }
}
