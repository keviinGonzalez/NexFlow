using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestHistory : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid ChangedBy { get; private set; }
        public string PropertyName { get; private set; }
        public string? OldValue { get; private set; }
        public string? NewValue { get; private set; }

        private RequestHistory()
        {
        }

        public RequestHistory(Guid requestId, Guid changedBy, string propertyName, string? oldValue, string? newValue)
        {
            Guard.ValidateRequired(requestId, nameof(requestId));
            Guard.ValidateRequired(changedBy, nameof(changedBy));
            Guard.ValidateRequired(propertyName, nameof(propertyName));
            Guard.ValidateMaxLength(propertyName, 100, nameof(propertyName));

            RequestId = requestId;
            ChangedBy = changedBy;
            PropertyName = propertyName.Trim();
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
