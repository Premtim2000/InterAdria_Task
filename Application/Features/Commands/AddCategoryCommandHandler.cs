using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Entities;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class AddCategoryCommandHandler : IAddCategoryCommandHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> Add(AddCategoryCommand category)
    {
        var commandToCategory = category.ToEntity();
        var result = await _categoryRepository.Add(commandToCategory);

        return result == null ? Result<CategoryResponse>.Fail(new Error
            ("prouct.add", "An error occurred while inserting")) : Result<CategoryResponse>.Successful(result.ToResponse());
    }
}
