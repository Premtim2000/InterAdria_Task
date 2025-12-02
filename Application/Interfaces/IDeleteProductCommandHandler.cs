using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IDeleteProductCommandHandler
{
    Task<Result<ProductResponse>> Delete(Guid Id);
}
