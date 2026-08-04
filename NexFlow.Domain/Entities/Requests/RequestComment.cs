using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestComment : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Comment { get; private set; }
        public bool IsInternal { get; private set; }

        private RequestComment()
        {
        }

        public RequestComment(Guid requestId, Guid authorId, string comment, bool isInternal = false)
        {
            RequestId = requestId;
            AuthorId = authorId;
            Edit(comment);
            IsInternal = isInternal;
        }

        public void Edit(string comment)
        {
            Guard.ValidateRequired(comment, nameof(comment));
            Guard.ValidateMaxLength(comment, 4000, nameof(comment));
            Comment = comment.Trim();
        }

        public void MarkAsInternal()
        {
            IsInternal = true;
        }

        public void MarkAsPublic()
        {
            IsInternal = false;
        }
    }
}
