using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistance;

internal class ApplicationDbContextInitialiser(ApplicationDbContext _context) : IApplicationDbContextInitialiser
{
    public async Task InitialiseAsync(CancellationToken ct = default)
    {
        if (_context.Database.IsNpgsql())
        {
            await _context.Database.MigrateAsync(ct);
        }
    }

    public async Task SeedAsync(CancellationToken ct = default)
    {
        if (!await _context.Products.AnyAsync(ct) && !await _context.Categories.AnyAsync(ct))
        {
            var fruits = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Fruits"
            };

            var vegetables = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Vegetables"
            };

            var drinks = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Drinks"
            };

            var apple = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Description = "Fresh red apples",
                PhotoUrl = "/images/apple.jpg",
                Price = 45.50m,
                Unit = "kg",
                IsAvailable = true,
                CategoryId = fruits.Id
            };

            var banana = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Banana",
                Description = "Sweet bananas",
                PhotoUrl = "/images/banana.jpg",
                Price = 60m,
                Unit = "kg",
                IsAvailable = true,
                CategoryId = fruits.Id
            };

            var tomato = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tomato",
                Description = "Fresh tomatoes",
                PhotoUrl = "/images/tomato.jpg",
                Price = 70m,
                Unit = "kg",
                IsAvailable = true,
                CategoryId = vegetables.Id
            };

            var cola = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Cola",
                Description = "Carbonated drink",
                PhotoUrl = "/images/cola.jpg",
                Price = 42m,
                Unit = "bottle",
                IsAvailable = true,
                CategoryId = drinks.Id
            };

            _context.Categories.AddRange(fruits, vegetables, drinks);
            _context.Products.AddRange(apple, banana, tomato, cola);

            await _context.SaveChangesAsync(ct);
        }
    }
}