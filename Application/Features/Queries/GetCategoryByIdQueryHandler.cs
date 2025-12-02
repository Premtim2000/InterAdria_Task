using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Queries;
public class GetCategoryByIdQueryHandler : IGetCategoryByIdQueryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> GetById(Guid id)
    {
        var result = await _categoryRepository.GetById(id);


        return result is null ? Result<CategoryResponse>.Fail(new Error("category.byId", "Category Not found!"))
            : Result<CategoryResponse>.Successful(result.ToResponse());
    }
}
