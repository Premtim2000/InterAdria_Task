using Application.DTOs;
using Application.Features.Contracts;
using Application.Responses;
using Core.Entities;

namespace Application.Mappings;
public static class CategoryMappings
{
    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            CreatedAt = category.CreatedAt,
            Description = category.Description,
            LastUpdatedAt = category.LastUpdatedAt,
            Name = category.Name
        };
    }

    public static Category ToEntity(this AddCategoryCommand category)
    {
        return new Category
        {
            CreatedAt = category.CreatedAt,
            Description = category.Description,
            LastUpdatedAt = category.LastUpdatedAt,
            Name = category.Name
        };
    }

    public static Category ToEntity(this UpdateCategoryCommand category)
    {
        return new Category
        {
            Description = category.Description,
            LastUpdatedAt = category.LastUpdatedAt,
            Name = category.Name
        };
    }

    public static AddCategoryCommand ToCommand(this AddCategoryDto category)
    {
        return new AddCategoryCommand
        {
            Description = category.Description,
            LastUpdatedAt = DateTime.Now,
            Name = category.Name,
            CreatedAt = DateTime.Now,
        };
    }

    public static UpdateCategoryCommand ToUpdateCommand(this UpdateCategoryDto category)
    {
        return new UpdateCategoryCommand
        {
            Description = category.Description,
            LastUpdatedAt = DateTime.Now,
            Name = category.Name,
        };
    }
}
