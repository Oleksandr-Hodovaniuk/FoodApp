namespace Catalog.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
    public bool IsAvailable { get; set; } = true;
    public Guid? CategoryId{ get; set; }
    public Category? Category { get; set; }
}