using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Catalogs
{
    public sealed class RequestType : AggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        private RequestType()
        {
        }

        public RequestType(string name, string? description)
        {
            Rename(name);
            ChangeDescription(description);
            IsActive = true;
        }

        public void Rename(string name)
        {
            Guard.ValidateRequired(name, nameof(name));
            Guard.ValidateMaxLength(name, 100, nameof(name));
            Name = name.Trim();
        }

        public void ChangeDescription(string? description)
        {
            Guard.ValidateMaxLength(description ?? string.Empty, 500, nameof(description));
            Description = description?.Trim();
        }

        public void Activate()
        {
            if (IsActive)
                return;
            IsActive = true;
        }

        public void Deactivate()
        {
            if (!IsActive)
                return;
            IsActive = false;
        }
    }
}
