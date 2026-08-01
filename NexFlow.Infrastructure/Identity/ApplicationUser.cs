using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace NexFlow.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public int DocumentTypeId { get; set; }

        public string IdentificationNumber { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = default!;

        public string? SecondLastName { get; set; }

        public bool IsEnabled { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public string FullName =>
            string.Join(" ", new[] { FirstName, MiddleName, LastName, SecondLastName }.Where(x => !string.IsNullOrWhiteSpace(x)));

        public void UpdateLastLogin()
        {
            LastLoginAt = DateTime.UtcNow;
        }

        public void UpdateProfile(
            int documentTypeId,
            string identificationNumber,
            string firstName,
            string? middleName,
            string lastName,
            string? secondLastName)
        {
            DocumentTypeId = documentTypeId;
            IdentificationNumber = identificationNumber;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SecondLastName = secondLastName;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
