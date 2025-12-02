using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Core.Repository;
using Core.Wrappers;

namespace Application.Features.Commands;
public class UpdateProductCommandHandler : IUpdateProductCommandHandler
{
    private readonly IProductRepository _productRepository;
    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<UpdateProductResponse>> Update(UpdateProductCommand updateProductCommand)
    {
        var productToUpdate = await _productRepository.GetById(updateProductCommand.Id);

        if (productToUpdate == null) 
        {
            return Result<UpdateProductResponse>.Fail(new Error("product.notFound", "Product not found"));
        }

        var updatedProduct = await _productRepository.Update(updateProductCommand.ToUpdate());

        if(updatedProduct == null)
        {
            return Result<UpdateProductResponse>.Fail(new Error("product.update", "An error Occurred while updating the product"));
        }

        return Result<UpdateProductResponse>.Successful(updatedProduct.ToUpdate());
    }
}
