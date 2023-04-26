using CarWorkshop.Application.Dtos;
using CarWorkshop.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        services.AddValidatorsFromAssemblyContaining<CarWorkshopDtoValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }

    private static void AddServices(this IServiceCollection services)
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
