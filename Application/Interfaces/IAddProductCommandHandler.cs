using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IAddProductCommandHandler
{
    Task<Result<ProductResponse>> Add(AddProductCommand productCommand);
}
