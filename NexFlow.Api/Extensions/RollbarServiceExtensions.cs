using Rollbar;
using Rollbar.NetCore.AspNet;
using Rollbar.NetPlatformExtensions;

namespace NexFlow.Api.Extensions
{
    public static class RollbarServiceExtensions
    {
        public static IServiceCollection AddRollbarMonitoring(this IServiceCollection services, IConfiguration configuration)
        {
            var accessToken =
          configuration["Rollbar:AccessToken"]
          ?? Environment.GetEnvironmentVariable("ROLLBAR_ACCESS_TOKEN");

            var environment =
                configuration["Rollbar:Environment"]
                ?? Environment.GetEnvironmentVariable("ROLLBAR_ENVIRONMENT")
                ?? "development";


            var config = new RollbarInfrastructureConfig(accessToken, environment);
            var dataSecurityOptions = new RollbarDataSecurityOptions();
            dataSecurityOptions.ScrubFields =
            [
                "password",
                "token",
                "secret",
                "api_key",
                "authorization"
            ];


            config.RollbarLoggerConfig.RollbarDataSecurityOptions.Reconfigure(dataSecurityOptions);
            RollbarInfrastructure.Instance.Init(config);

            return services;
        }
    }
}
