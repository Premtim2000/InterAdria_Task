using Application.DTOs;

namespace Application.Features.Contracts;
public class GetProductsQuery : GetQueryDto
{
    public string MinMax { get; set; }
}
