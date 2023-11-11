using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Services.Authentication;

namespace ZehirZikkim.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
