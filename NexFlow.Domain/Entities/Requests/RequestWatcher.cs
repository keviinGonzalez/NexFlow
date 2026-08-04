using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestWatcher : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid UserId { get; private set; }

        private RequestWatcher()
        {
        }

        public RequestWatcher(Guid requestId, Guid userId)
        {
            Guard.ValidateRequired(requestId, nameof(requestId));
            Guard.ValidateRequired(userId, nameof(userId));

            RequestId = requestId;
            UserId = userId;
        }
    }
}
