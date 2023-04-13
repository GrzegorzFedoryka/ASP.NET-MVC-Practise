using CarWorkshop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        var assemblyServices = typeof(IServiceMarker).Assembly.GetTypes()
                .Where(x => typeof(IServiceMarker).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        foreach (var serviceType in assemblyServices)
        {
            var interfaces = serviceType.GetInterfaces().Except(new[] { typeof(IServiceMarker) });
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, serviceType);
            }
        }
    }

}
