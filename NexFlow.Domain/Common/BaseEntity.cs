using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset CreatedAt { get; protected set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsUpdated()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
        }
        public void MarkAsRestored()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
