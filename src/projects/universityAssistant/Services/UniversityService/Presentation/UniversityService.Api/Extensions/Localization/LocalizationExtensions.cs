using System.Globalization;

namespace UniversityService.Api.Extensions.Localization;

public static class LocalizationExtensions
{
    public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
    {
        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new("tr-TR");

            CultureInfo[] cultures = new CultureInfo[]
            {
                new("tr-TR"),
                new("en-US"),
            };

            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
        });

        return services;
    }
}
