using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class DeleteCategoryCommandHandler : IDeleteCategoryCommandHandler
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> Delete(Guid id)
    {
        var deletedCategory = await _categoryRepository.Delete(id);

        return deletedCategory is null ?
            Result<CategoryResponse>.Fail(new Error("category.delete", "Delete failed!"))
            :
            Result<CategoryResponse>.Successful(deletedCategory.ToResponse());
    }
}
