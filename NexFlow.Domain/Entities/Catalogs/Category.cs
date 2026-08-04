using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Catalogs
{
    public sealed class Category : AggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? Color { get; private set; }
        public bool IsActive { get; private set; }

        private Category() { }

        public Category(string name, string? description, string? color, bool isActive)
        {
            Name = name;
            Description = description;
            Color = color;
            IsActive = isActive;
        }

        public void Rename(string name)
        {
            Guard.ValidateRequired(name, nameof(name));
            Guard.ValidateMaxLength(name, 100, nameof(name));
            Name = name;
        }

        public void ChangeDescription(string? description)
        {
            Guard.ValidateMaxLength(description ?? string.Empty, 500, nameof(description));
            Description = description?.Trim();     
        }

        public void ChangeColor(string? color)
        {
            Guard.ValidateMaxLength(color ?? string.Empty, 20, nameof(color));
            Color = color?.Trim();          
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
