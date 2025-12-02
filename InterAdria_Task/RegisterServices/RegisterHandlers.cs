using Application.Features.Commands;
using Application.Features.Queries;
using Application.Features.Wrapper;
using Application.Interfaces;
using Core.Repository;
using Infrastructure.Repositories;

namespace InterAdria_Task.RegisterServices;

public static class RegisterHandlers
{
    public static IServiceCollection RegisterHandlerServices(this IServiceCollection service)
    {
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IProductHandlers, ProductHandlers>();
        service.AddScoped<ICategoryHandlers, CategoryHandlers>();

        return service;
    }
}
