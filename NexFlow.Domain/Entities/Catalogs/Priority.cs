using NexFlow.Domain.Common.Base;
using NexFlow.Domain.Common.Guards;
using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Entities.Catalogs
{
    public sealed class Priority : AggregateRoot
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public string? Color { get; private set; }
        public int ResponseTimeHours { get; private set; }
        public int ResolutionTimeHours { get; private set; }
        public bool IsActive { get; private set; }

        private Priority()
        {
        }

        public Priority(string name, int level, string? color, int responseTimeHours, int resolutionTimeHours, bool isActive)
        {
            Rename(name);
            ChangeLevel(level);
            ChangeColor(color);
            ConfigureSla(responseTimeHours, resolutionTimeHours);
            IsActive = isActive;
        }

        public void Rename(string name)
        {
            Guard.ValidateRequired(name, nameof(name));
            Guard.ValidateMaxLength(name, 100, nameof(name));
            Name = name.Trim();
        }

        public void ChangeLevel(int level)
        {
            if (level < 1)
                throw new DomainException("Level must be greater than zero.");
            Level = level;
        }

        public void ChangeColor(string? color)
        {
            Guard.ValidateMaxLength(color ?? string.Empty, 20, nameof(color));
            Color = color?.Trim();
        }

        public void ConfigureSla(
            int responseTimeHours,
            int resolutionTimeHours)
        {
            ResponseTimeHours = responseTimeHours;
            ResolutionTimeHours = resolutionTimeHours;
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
