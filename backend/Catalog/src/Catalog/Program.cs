using Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseApiServices();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
