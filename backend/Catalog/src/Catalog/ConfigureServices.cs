using Catalog.Application.Interfaces;
using Scalar.AspNetCore;

namespace Catalog;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.MapScalarApiReference(options =>
            {
                options.WithOpenApiRoutePattern("/swagger/{documentName}/swagger.json");
            });
        }

        return app;
    }

    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<IApplicationDbContextInitialiser>();

        await dbInitialiser.InitialiseAsync();
        await dbInitialiser.SeedAsync();
    }
}