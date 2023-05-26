using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace MessagePersistenceService.Api.Extensions.HealthCheck;

public static class HealtCheckConfigureExtension
{
    public static IApplicationBuilder UseCustomHealtCheck(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseHealthChecks(configuration["HealthCheck:ApiAddress"], new HealthCheckOptions()
        {
            ResponseWriter = async (context, report) =>
            {
                await context.Response.WriteAsync("OK");
            }
        });

        return app;
    }
}
