using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class DeleteProductCommandHandler : IDeleteProductCommandHandler
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse>> Delete(Guid Id)
    {
        var deletedProduct = await _productRepository.Delete(Id);

        if(deletedProduct == null)
        {
            return Result<ProductResponse>.Fail(new Error("Products.remove", "Error while deleting the product"));
        }

        return Result<ProductResponse>.Successful(deletedProduct.ToProductResponse());
    }
}
