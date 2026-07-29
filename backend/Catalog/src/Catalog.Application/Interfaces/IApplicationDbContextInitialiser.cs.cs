namespace Catalog.Application.Interfaces;

public interface IApplicationDbContextInitializer
{
    Task InitializeAsync(CancellationToken ct = default);
    Task SeedAsync(CancellationToken ct = default);
}
