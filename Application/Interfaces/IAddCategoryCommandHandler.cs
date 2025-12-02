using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IAddCategoryCommandHandler
{
    Task<Result<CategoryResponse>> Add(AddCategoryCommand category);
}
