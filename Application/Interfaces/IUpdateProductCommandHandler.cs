using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IUpdateProductCommandHandler
{
    Task<Result<UpdateProductResponse>> Update(UpdateProductCommand updateProductCommand);
}
