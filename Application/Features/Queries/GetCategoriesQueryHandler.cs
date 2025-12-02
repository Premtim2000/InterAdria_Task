using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Queries;
public class GetCategoriesQueryHandler : IGetCategoriesQueryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<PaginatedResult<IEnumerable<CategoryResponse>>> Get(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.Get(request.PageNumber, request.PageSize).ConfigureAwait(false);

        var resultResponse = result.Select(p => p.ToResponse());

        return new PaginatedResult<IEnumerable<CategoryResponse>>
        {
            Data = resultResponse,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = result.Count(),
        };
    }
}
