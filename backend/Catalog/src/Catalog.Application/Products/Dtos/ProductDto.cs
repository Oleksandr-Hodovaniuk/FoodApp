using Catalog.Application.Categories.Dtos;

namespace Catalog.Application.Products.Dtos;

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