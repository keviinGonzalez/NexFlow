using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common.Guards
{
    public static class Guard
    {
        public static void ValidateRequired(string? value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException($"{parameterName} is required.");
            }
        }

        public static void ValidateRequired(Guid value, string parameterName)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException($"{parameterName} is required.");
            }
        }

        public static void ValidateRequired(Guid? value, string parameterName)
        {
            if (!value.HasValue || value.Value == Guid.Empty)
            {
                throw new DomainException($"{parameterName} is required.");
            }
        }

        public static void ValidateMaxLength(string value, int maxLength, string parameterName)
        {
            if (value.Length > maxLength)
            {
                throw new DomainException($"{parameterName} cannot exceed {maxLength} characters.");
            }
        }

        public static void ValidateMinLength(string value, int minLength, string parameterName)
        {
            if (value.Length < minLength)
            {
                throw new DomainException($"{parameterName} cannot be less than {minLength} characters.");
            }
        }

        public static void ValidatePositive(int value, string parameterName)
        {
            if (value <= 0)
                throw new DomainException($"{parameterName} must be greater than zero.");
        }

        public static void ValidatePositive(decimal value, string parameterName)
        {
            if (value <= 0)
                throw new DomainException($"{parameterName} must be greater than zero.");
        }

        public static void ValidateRange(int value, int min, int max, string parameterName)
        {
            if (value < min || value > max)
                throw new DomainException($"{parameterName} must be between {min} and {max}.");
        }
    }
}
