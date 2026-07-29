using Catalog.Application.Categories.Dtos;
using Catalog.Application.Interfaces;
using MediatR;

namespace Catalog.Application.Categories.Commands;

public record CreateCategoryHandler(IApplicationDbContext _context) 
    : IRequestHandler<CreateCategoryDto, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryDto request, CancellationToken ct = default)
    {


        return new CategoryDto();
    }
}
