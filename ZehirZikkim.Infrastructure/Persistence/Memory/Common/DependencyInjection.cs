
using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Infrastructure.Persistence.Memory.Repositories;



namespace ZehirZikkim.Infrastructure.Persistence.Memory.Common;




public static class DependencyInjection {
    public static IServiceCollection UseMemoryPersistence(this IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;

    }
}