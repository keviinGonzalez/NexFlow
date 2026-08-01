using NexFlow.Domain.Common;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities
{
    public class Request : BaseEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        private Request()
        {
            // Constructor requerido por Entity Framework.
        }

        public Request(string title, string description)
        {
            ValidateRequest(title, description);
            SetValues(title, description);
        }

        /// <summary>
        /// Actualiza la información de la solicitud.
        /// </summary>
        public void Update(string title, string description)
        {
            ValidateRequest(title, description);
            SetValues(title, description);
            MarkAsUpdated();
        }

        private void SetValues(string title, string description)
        {
            Title = title.Trim();
            Description = description?.Trim() ?? string.Empty;
        }

        private static void ValidateRequest(string title, string description)
        {
            Guard.ValidateRequired(title, nameof(title));
            Guard.ValidateMaxLength(title, 150, nameof(title));
            Guard.ValidateMaxLength(description ?? string.Empty, 1000, nameof(description));
        }
        public void Delete()
        {
            MarkAsDeleted();
        }
    }
}
