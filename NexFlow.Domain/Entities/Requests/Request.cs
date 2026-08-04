using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using NexFlow.Domain.Entities.Catalogs;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class Request : AggregateRoot
    {
        public string Code { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = default!;
        public Guid PriorityId { get; private set; }
        public Priority Priority { get; private set; } = default!;
        public Guid StatusId { get; private set; }
        public Status Status { get; private set; } = default!;
        public Guid RequestTypeId { get; private set; }
        public RequestType RequestType { get; private set; } = default!;
        public Guid ReporterId { get; private set; }
        public Guid? AssigneeId { get; private set; }
        public DateTimeOffset? DueDate { get; private set; }
        public DateTimeOffset? ClosedAt { get; private set; }
        public bool IsClosed => ClosedAt.HasValue;


        private readonly List<RequestComment> _comments = [];

        private readonly List<RequestAttachment> _attachments = [];

        private readonly List<RequestActivity> _activities = [];

        private readonly List<RequestHistory> _history = [];

        private readonly List<RequestWatcher> _watchers = [];

        private readonly List<RequestTag> _tags = [];

        public IReadOnlyCollection<RequestComment> Comments => _comments.AsReadOnly();

        public IReadOnlyCollection<RequestAttachment> Attachments => _attachments.AsReadOnly();

        public IReadOnlyCollection<RequestActivity> Activities => _activities.AsReadOnly();

        public IReadOnlyCollection<RequestHistory> History => _history.AsReadOnly();

        public IReadOnlyCollection<RequestWatcher> Watchers => _watchers.AsReadOnly();

        public IReadOnlyCollection<RequestTag> Tags => _tags.AsReadOnly();

        private Request()
        {
        }

        public Request(string code, string title, string description, Guid categoryId, Guid priorityId, Guid statusId,
        Guid requestTypeId, Guid reporterId)
        {
            ChangeCode(code);
            Rename(title);
            ChangeDescription(description);

            ChangeCategory(categoryId);
            ChangePriority(priorityId);
            ChangeStatus(statusId);
            ChangeRequestType(requestTypeId);

            ReporterId = reporterId;
        }

        public void Rename(string title)
        {
            Guard.ValidateRequired(title, nameof(title));
            Guard.ValidateMaxLength(title, 150, nameof(title));

            Title = title.Trim();
        }

        public void ChangeDescription(string description)
        {
            Guard.ValidateRequired(description, nameof(description));
            Guard.ValidateMaxLength(description, 2000, nameof(description));

            Description = description.Trim();
        }

        public void ChangeCategory(Guid categoryId)
        {
            Guard.ValidateRequired(categoryId, nameof(categoryId));
            CategoryId = categoryId;
        }

        public void ChangePriority(Guid priorityId)
        {
            Guard.ValidateRequired(priorityId, nameof(priorityId));
            PriorityId = priorityId;
        }

        public void ChangeStatus(Guid statusId)
        {
            Guard.ValidateRequired(statusId, nameof(statusId));
            StatusId = statusId;
        }

        public void ChangeRequestType(Guid requestTypeId)
        {
            Guard.ValidateRequired(requestTypeId, nameof(requestTypeId));
            RequestTypeId = requestTypeId;
        }

        public void Assign(Guid assigneeId)
        {
            Guard.ValidateRequired(assigneeId, nameof(assigneeId));
            AssigneeId = assigneeId;
        }

        public void Unassign()
        {
            AssigneeId = null;
        }

        public void Schedule(DateTimeOffset dueDate)
        {
            DueDate = dueDate;
        }

        public void Close()
        {
            if (IsClosed)
                return;

            ClosedAt = DateTimeOffset.UtcNow;
        }

        public void Reopen()
        {
            if (!IsClosed)
                return;

            ClosedAt = null;
        }

        private void ChangeCode(string code)
        {
            Guard.ValidateRequired(code, nameof(code));
            Guard.ValidateMaxLength(code, 20, nameof(code));
            Code = code.Trim();
        }
    }
}
