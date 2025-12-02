using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IGetCategoriesQueryHandler
{
    Task<PaginatedResult<IEnumerable<CategoryResponse>>> Get(GetCategoryQuery request, CancellationToken cancellationToken);
}
