
using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ZehirZikkim.Application.Common.Behaviors;

namespace ZehirZikkim.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>)
        );
        services.AddValidatorsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        return services;
    }
}
