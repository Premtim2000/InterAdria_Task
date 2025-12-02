using Application.DTOs;
using Application.Features.Contracts;
using Application.Responses;
using Core.Entities;

namespace Application.Mappings;
public static class ProductMappings
{
    public static Product ToProduct(this AddProductCommand product)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            CategoryId = product.CategoryId,
            CreatedAt = DateTime.UtcNow,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            LastUpdatedAt = DateTime.UtcNow
        };
    }

    public static ProductResponse ToProductResponse(this Product product)
    {
        return new ProductResponse
        {
            Category = product.Category.ToResponse(),
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CreatedAt = product.CreatedAt,
            LastUpdatedAt = product.LastUpdatedAt,
        };
    }

    public static UpdateProductResponse ToUpdate(this Product product)
    {
        return new UpdateProductResponse
        {
            Category = product.Category,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CreatedAt = product.CreatedAt,
            LastUpdatedAt = product.LastUpdatedAt,
        };
    }

    public static Product ToUpdate(this UpdateProductCommand product)
    {
        return new Product
        {
            CategoryId = product.CategoryId,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            LastUpdatedAt = DateTime.Now,
        };
    }

    public static AddProductCommand ToCommand(this AddProductDto product)
    {
        return new AddProductCommand
        {
            Name = product.Name,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Stock = product.Stock,
            CreatedAt = DateTime.Now,
        };
    }

    public static UpdateProductCommand ToUpdateCommand(this UpdateProductDto product)
    {
        return new UpdateProductCommand
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            LastUpdatedAt = DateTime.UtcNow
        };
    }
}
