using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IGetCategoryByIdQueryHandler
{
    Task<Result<CategoryResponse>> GetById(Guid id);
}
