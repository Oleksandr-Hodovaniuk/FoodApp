using Catalog;
using Catalog.Infrastructure;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

//Load .env file.

Env.Load("../../../../.env");
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddApiServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.InitialiseDatabaseAsync();

// Configure the HTTP request pipeline.

app.UseApiServices();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();