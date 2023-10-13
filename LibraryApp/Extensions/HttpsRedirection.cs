using System.Net;

namespace LibraryApp.Extensions;

public static class HttpsRedirection
{
    public static IServiceCollection AddApplicationServicesHttps(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
            options.HttpsPort = 5229;
        });

        return services;
    }
}