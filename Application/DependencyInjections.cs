using Application.Services;
using Application.Services.Hall;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    { 
        services.AddScoped<CreateHall>();
        return services;
    }
}