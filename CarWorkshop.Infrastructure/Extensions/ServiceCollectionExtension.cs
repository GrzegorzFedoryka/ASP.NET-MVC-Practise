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
    }
}
