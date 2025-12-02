using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IDeleteCategoryCommandHandler
{
    Task<Result<CategoryResponse>> Delete(Guid id);
}
