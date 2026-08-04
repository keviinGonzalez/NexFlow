using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestActivity : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid PerformedBy { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset OccurredAt { get; private set; }

        private RequestActivity()
        {
        }

        public RequestActivity(Guid requestId, Guid performedBy, string description)
        {
            Guard.ValidateRequired(requestId, nameof(requestId));
            Guard.ValidateRequired(performedBy, nameof(performedBy));
            Guard.ValidateRequired(description, nameof(description));
            Guard.ValidateMaxLength(description, 500, nameof(description));

            RequestId = requestId;
            PerformedBy = performedBy;
            Description = description.Trim();
            OccurredAt = DateTimeOffset.UtcNow;
        }
    }
}
