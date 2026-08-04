using NexFlow.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common.Base
{
    public abstract class SoftDeletableEntity : AuditableEntity, ISoftDeletable
    {
        public bool IsDeleted { get; protected set; }
        public DateTimeOffset? DeletedAt { get; protected set; }

        public virtual void SoftDelete()
        {
            if (IsDeleted)
                return;

            IsDeleted = true;
            //DeletedAt = DateTimeOffset.UtcNow;

            //MarkAsUpdated();
        }

        public virtual void Restore()
        {
            if (!IsDeleted)
                return;

            IsDeleted = false;
            //DeletedAt = null;

            //MarkAsUpdated();
        }
    }
}
