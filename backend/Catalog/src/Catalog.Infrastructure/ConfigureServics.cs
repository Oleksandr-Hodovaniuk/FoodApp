using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class ConfigureServics
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["CATALOG_DB_CONNECTION_STRING"];

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContextInitializer, ApplicationDbContextInitializer>();

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
