using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class AddProductCommandHandler : IAddProductCommandHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public AddProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<ProductResponse>> Add(AddProductCommand productCommand)
    {
        var commandToProduct = productCommand.ToProduct();

        var category = await _categoryRepository.GetById(productCommand.CategoryId);

        var result = await _productRepository.Add(commandToProduct);

        var response = new ProductResponse
        {
            Name = result.Name,
            Price = result.Price,
            Stock = result.Stock,
            Category = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            },
            CreatedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow
        };
        return result == null ? Result<ProductResponse>.Fail(new Error
            ("prouct.add", "An error occurred while inserting")) : Result<ProductResponse>.Successful(response);
    }
}
