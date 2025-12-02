using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IUpdateCategoryCommandHandler
{
    Task<Result<CategoryResponse>> Update(UpdateCategoryCommand updateCategoryCommand);
}
