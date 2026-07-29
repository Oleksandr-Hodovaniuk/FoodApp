using MediatR;

namespace Catalog.Application.Categories.Dtos;

public class CreateCategoryDto : IRequest<CategoryDto>
{
    public string Name { get; set; } = null!;
}