using NexFlow.Domain.Common.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Catalogs
{
    public sealed class Tag
    {
        public string Name { get; private set; }

        public string? Color { get; private set; }

        private Tag()
        {
        }

        public Tag(string name, string? color)
        {
            Rename(name);
            ChangeColor(color);
        }

        public void Rename(string name)
        {
            Guard.ValidateRequired(name, nameof(name));
            Guard.ValidateMaxLength(name, 100, nameof(name));
            Name = name.Trim();
        }

        public void ChangeColor(string? color)
        {
            Guard.ValidateMaxLength(color ?? string.Empty, 20, nameof(color));
            Color = color?.Trim();
        }
    }
}
