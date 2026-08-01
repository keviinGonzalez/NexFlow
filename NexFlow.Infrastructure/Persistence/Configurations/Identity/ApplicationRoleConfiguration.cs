using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFlow.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Infrastructure.Persistence.Configurations.Identity
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles");
        }
    }
}
