using System.Reflection.Metadata.Ecma335;
using Application.Features.Commands;
using Application.Features.Queries;
using Application.Interfaces;

namespace InterAdria_Task.RegisterServices;

public static class RegisterCommands
{
    public static IServiceCollection RegisterHandlerCommands(this IServiceCollection service)
    {
        service.AddScoped<IAddCategoryCommandHandler, AddCategoryCommandHandler>();
        service.AddScoped<IGetCategoryByIdQueryHandler, GetCategoryByIdQueryHandler>();
        service.AddScoped<IGetCategoriesQueryHandler, GetCategoriesQueryHandler>();
        service.AddScoped<IUpdateCategoryCommandHandler, UpdateCategoryCommandHandler>();
        service.AddScoped<IDeleteCategoryCommandHandler, DeleteCategoryCommandHandler>();
        service.AddScoped<IGetCategoriesQueryHandler, GetCategoriesQueryHandler>();
        service.AddScoped<IAddProductCommandHandler, AddProductCommandHandler>();
        service.AddScoped<IUpdateProductCommandHandler, UpdateProductCommandHandler>();
        service.AddScoped<IDeleteProductCommandHandler, DeleteProductCommandHandler>();
        service.AddScoped<IGetProductsQueryHandler, GetProductsQueryHandler>();
        service.AddScoped<IGetProductByIdQueryHandler, GetProductByIdQueryHandler>();
        service.AddScoped<IAddCategoryCommandHandler, AddCategoryCommandHandler>();
        service.AddScoped<IGetCategoryByIdQueryHandler, GetCategoryByIdQueryHandler>();

        return service;
    }
}
