using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Services.Authentication.Commands;
using ZehirZikkim.Application.Services.Authentication.Queries;

namespace ZehirZikkim.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        return services;
    }
}
