using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Common.Interfaces.Authentication;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Application.Common.Interfaces.Services;
using ZehirZikkim.Infrastructure.Authentication;
using ZehirZikkim.Infrastructure.Persistence;
using ZehirZikkim.Infrastructure.Services;

namespace ZehirZikkim.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration) {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
