using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence.Extensions;

public static class DatabaseServiceCollectionExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        // Add configuration for ApplicationDbContext with retry logic
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContextFactory<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                npgsql =>
                {
                    npgsql.MigrationsAssembly(
                        typeof(ApplicationDbContext)
                            .Assembly
                            .FullName
                    );

                    npgsql.EnableRetryOnFailure(
                        5,
                        TimeSpan.FromSeconds(30),
                        null
                    );
                });
            
                #if DEBUG
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                #endif
        });
        return services;
    }
}