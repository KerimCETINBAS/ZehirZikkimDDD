
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Common.Interfaces.Persistence;



namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Common;




public static partial class DependencyInjection {
    public static IServiceCollection UseMemoryPersistence(this IServiceCollection services) {
        
        services.AddDbContext<ZehirZikkimDbContext>(options =>
            options.UseSqlServer("Servcer=localhost,1433;Database=ZehirZikkim;User Id=sa;Password=password")
        );
        return services;

    }
}