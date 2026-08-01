using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Infrastructure.Identity
{
    public sealed class IdentitySeeder
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentitySeeder(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedAdministratorAsync();
        }
        private async Task SeedRolesAsync()
        {
            await CreateRoleIfNotExistsAsync(IdentityConstants.AdministratorRole);
            await CreateRoleIfNotExistsAsync(IdentityConstants.UserRole);
        }

        private async Task CreateRoleIfNotExistsAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return;

            var result = await _roleManager.CreateAsync(
                new ApplicationRole
                {
                    Name = roleName
                });

            EnsureSuccess(result);
        }


        private async Task SeedAdministratorAsync()
        {
            var admin = await _userManager.FindByEmailAsync(IdentityConstants.DefaultAdminEmail);
            if (admin is not null)
                return;

            admin = new ApplicationUser
            {
                Email = IdentityConstants.DefaultAdminEmail,
                UserName = IdentityConstants.DefaultAdminEmail,
                FirstName = "System",
                LastName = "Administrator",
                DocumentTypeId = 1,
                IdentificationNumber = "1152700340",
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _userManager.CreateAsync(admin, IdentityConstants.DefaultAdminPassword);

            EnsureSuccess(result);

            result = await _userManager.AddToRoleAsync(admin, IdentityConstants.AdministratorRole);
            EnsureSuccess(result);
        }

        private static void EnsureSuccess(IdentityResult result)
        {
            if (result.Succeeded)
                return;

            var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
            throw new InvalidOperationException(errors);
        }
    }
}
