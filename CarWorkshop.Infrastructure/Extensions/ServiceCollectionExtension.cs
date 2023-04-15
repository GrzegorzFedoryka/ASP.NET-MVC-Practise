using CarWorkshop.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CarWorkshop.Infrastructure.Seeders;
using CarWorkshop.Infrastructure.Repositories;

namespace CarWorkshop.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionSting = configuration.GetConnectionString("CarWorkshop");
        services.AddDbContext<CarWorkshopDbContext>(options =>
        {
            options.UseSqlServer(connectionSting);
        });

        services.AddScoped<CarWorkshopSeeder>();
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        var assemblyServices = typeof(IRepositoryMarker).Assembly.GetTypes()
                .Where(x => typeof(IRepositoryMarker).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        foreach (var serviceType in assemblyServices)
        {
            var interfaces = serviceType.GetInterfaces().Except(new[] { typeof(IRepositoryMarker) });
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, serviceType);
            }
        }
    }
}
