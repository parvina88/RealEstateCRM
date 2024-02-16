using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RealEstate.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Scoped);
        return services;
    }
}
