using Catalog.Application.Dtos.Category;
using Catalog.Domain.Entities;

namespace Catalog.Application.Dtos.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
    public bool IsAvailable { get; set; }
    public CategoryDto? Category { get; set; }
}