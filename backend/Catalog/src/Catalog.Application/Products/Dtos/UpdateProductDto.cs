
namespace Catalog.Application.Products.Dtos;

public class UpdateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
    public decimal? Price { get; set; }
    public string? Unit { get; set; } 
    public bool? IsAvailable { get; set; }
    public Guid? CategoryId { get; set; }
}