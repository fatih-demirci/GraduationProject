using UniversityService.Api.Middlewares;

namespace UniversityService.Api.Extensions.Localization;

public static class RequestLocalizationCookiesMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
        => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
}
