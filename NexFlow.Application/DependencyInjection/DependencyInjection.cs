using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NexFlow.Application.Behaviors;
using NexFlow.Application.Features.Request.Commands.CreateRequest;

namespace NexFlow.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateRequestHandler).Assembly);

                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(CreateRequestHandler).Assembly);

            return services;
        }
    }
}
