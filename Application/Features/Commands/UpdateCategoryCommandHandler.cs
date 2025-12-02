using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class UpdateCategoryCommandHandler : IUpdateCategoryCommandHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> Update(UpdateCategoryCommand updateCategoryCommand)
    {
        var categoryToUpdate = await _categoryRepository.Update(updateCategoryCommand.ToEntity());

        return categoryToUpdate is null ? 
            Result<CategoryResponse>.Fail(new Error("category.update", "Update failed!")) 
            : 
            Result<CategoryResponse>.Successful(categoryToUpdate.ToResponse());
    }
}
