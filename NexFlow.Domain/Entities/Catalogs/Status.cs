using NexFlow.Domain.Common.Guards;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Catalogs
{
    public sealed class Status
    {
        public string Name { get; private set; }
        public int Order { get; private set; }
        public string? Color { get; private set; }
        public bool IsInitial { get; private set; }
        public bool IsFinal { get; private set; }
        public bool IsActive { get; private set; }

        private Status()
        {
        }

        public Status(string name, int order, string? color, bool isInitial, bool isFinal)
        {
            Rename(name);
            ChangeOrder(order);
            ChangeColor(color);
            IsInitial = isInitial;
            IsFinal = isFinal;
            IsActive = true;
        }

        public void Rename(string name)
        {
            Guard.ValidateRequired(name, nameof(name));
            Guard.ValidateMaxLength(name, 100, nameof(name));
            Name = name.Trim();
        }

        public void ChangeOrder(int order)
        {
            if (order < 1)
                throw new DomainException("Order must be greater than zero.");
            Order = order;
        }

        public void ChangeColor(string? color)
        {
            Guard.ValidateMaxLength(color ?? string.Empty, 20, nameof(color));
            Color = color?.Trim();
        }

        public void MarkAsInitial()
        {
            IsInitial = true;
        }

        public void RemoveAsInitial()
        {
            IsInitial = false;
        }

        public void MarkAsFinal()
        {
            IsFinal = true;
        }

        public void RemoveAsFinal()
        {
            IsFinal = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
