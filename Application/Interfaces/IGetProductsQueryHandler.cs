using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface IGetProductsQueryHandler
{
    Task<PaginatedResult<IEnumerable<ProductResponse>>> Get(GetProductsQuery request);
}
