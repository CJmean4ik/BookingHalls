using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        services.AddSerilog();

        return services;
    } 
}