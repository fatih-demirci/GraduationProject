using IdentityService.Api.Middlewares;

namespace IdentityService.Api.Extensions.Localization
{
    public static class RequestLocalizationCookiesMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
    }
}
