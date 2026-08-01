using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexFlow.Application.Abstractions.Persistence;
using NexFlow.Application.Common.Interfaces;
using NexFlow.Infrastructure.Authentication;
using NexFlow.Infrastructure.Identity;
using NexFlow.Infrastructure.Persistence.Context;
using NexFlow.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtOptions>(
            configuration.GetSection("Jwt"));

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddRoles<ApplicationRole>().AddEntityFrameworkStores<AppDbContext>();
            //.AddDefaultTokenProviders();

            services.AddScoped<IdentitySeeder>();
            services.AddHttpContextAccessor();

            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICurrentUser, CurrentUser>();


            return services;
        }
    }
}
