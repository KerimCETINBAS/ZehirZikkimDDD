
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ZehirZikkim.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR( x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
