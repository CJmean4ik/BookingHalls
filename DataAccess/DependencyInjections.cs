using DataAccess.Contexts;
using DataAccess.Repositories;
using Domain.Contracts;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjections
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingHallsContext>(c => c.UseSqlServer(configuration.GetConnectionString("MSSQL")));
        
        services.AddScoped<IAvailableServicesRepository,AvailableServicesRepository>();
        services.AddScoped<IBookedHallsRepository,BookedHallsRepository>();
        services.AddScoped<IServicesRepository,ServicesRepository>();
        services.AddScoped<IHallRepository,HallRepository>();
        
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        return services;
    }
}