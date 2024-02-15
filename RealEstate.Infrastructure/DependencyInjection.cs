using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Data;
using RealEstate.Application.Services;
using RealEstate.Domain.Repositories;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbInitializer, ApplicationDbInitializer>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IBuildingService, BuildingService>();


        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (configuration["UseInMemoryDatabase"] == "true")
                options.UseInMemoryDatabase("testDb");
            else
                options.UseSqlServer(connectionString);
        });

        return services;
    }
}