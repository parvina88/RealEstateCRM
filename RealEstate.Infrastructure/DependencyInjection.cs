using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Data;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbInitializer, ApplicationDbInitializer>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IEntranceRepository, EntranceRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();

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