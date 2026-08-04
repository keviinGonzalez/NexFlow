using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using NexFlow.Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestTag : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid TagId { get; private set; }
        public Tag Tag { get; private set; } = default!;

        private RequestTag()
        {
        }

        public RequestTag(Guid requestId, Guid tagId)
        {
            Guard.ValidateRequired(requestId, nameof(requestId));
            Guard.ValidateRequired(tagId, nameof(tagId));

            RequestId = requestId;
            TagId = tagId;
        }
    }
}
