using NexFlow.Domain.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Requests
{
    public sealed class RequestAttachment : AggregateRoot
    {
        public Guid RequestId { get; private set; }
        public Guid UploadedBy { get; private set; }
        public string FileName { get; private set; }
        public string StoredFileName { get; private set; }
        public string ContentType { get; private set; }
        public string Extension { get; private set; }
        public long Size { get; private set; }

        private RequestAttachment()
        {
        }

        public RequestAttachment(Guid requestId, Guid uploadedBy, string fileName, string storedFileName, string contentType,
            string extension, long size)
        {
            RequestId = requestId;
            UploadedBy = uploadedBy;
            FileName = fileName;
            StoredFileName = storedFileName;
            ContentType = contentType;
            Extension = extension;
            Size = size;
        }
    }
}
