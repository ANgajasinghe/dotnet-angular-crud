using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("default");
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder
                .UseInMemoryDatabase("InMem")
                // .UseSqlServer(connectionString, sqlServerOptionsBuilder =>
                // {
                //     sqlServerOptionsBuilder.EnableRetryOnFailure();
                //     sqlServerOptionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                //     sqlServerOptionsBuilder.MigrationsAssembly("WebApi");
                // })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine, LogLevel.Information);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
    
}