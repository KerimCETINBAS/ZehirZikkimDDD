using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

        services
            .AddAuth(configuration)
            .AddPersistence();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration) {
            JwtSettings jwtSettings = new();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();

            services.AddAuthentication(
                defaultScheme: JwtBearerDefaults.AuthenticationScheme
            ).AddJwtBearer( options => options.TokenValidationParameters = new TokenValidationParameters(){
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Access.Issuer,
                ValidAudience =  jwtSettings.Access.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Access.Secret)
                )
            });
            return services;
        }
}
