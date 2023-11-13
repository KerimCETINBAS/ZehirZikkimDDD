

using Microsoft.AspNetCore.Mvc.Infrastructure;
using ZehirZikkim.Api.Common.Errors;
using ZehirZikkim.Api.Common.Mapping;

namespace ZehirZikkim.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        services.AddControllers();
        services.AddMappings();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, ZehirZikkimProblemDetailsFactory>();
        return services;
    }
}
