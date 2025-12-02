using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Queries;
public class GetProductByIdQueryHandler : IGetProductByIdQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse>> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id);

        return product == null ? Result<ProductResponse>.Fail(new Error("product.notFound", "Product not found")) : Result<ProductResponse>.Successful(product.ToProductResponse());
    }
}
