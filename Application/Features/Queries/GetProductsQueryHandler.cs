using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Queries;
public class GetProductsQueryHandler : IGetProductsQueryHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PaginatedResult<IEnumerable<ProductResponse>>> Get(GetProductsQuery request)
    {
        var products = await _productRepository.Get(
            request.PageNumber,
            request.PageSize,
            request.MinMax);

        return new PaginatedResult<IEnumerable<ProductResponse>>
        {
            Data = products.Select(p => new ProductResponse
            {
                Category = p.Category.ToResponse(),
                CreatedAt = DateTime.Now,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
        };
    }
}
