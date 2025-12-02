using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IGetProductByIdQueryHandler
{
    Task<Result<ProductResponse>> GetById(Guid id);
}
