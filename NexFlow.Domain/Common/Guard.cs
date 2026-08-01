using NexFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Domain.Common
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
    }
}
