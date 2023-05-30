using MessagePersistenceService.Api.Middlewares;

namespace MessagePersistenceService.Api.Extensions.Localization;

public static class RequestLocalizationCookiesMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
        => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
}
