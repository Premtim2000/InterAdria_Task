using Application.Interfaces;

namespace Application.Features.Wrapper;
public class CategoryHandlers : ICategoryHandlers
{
    public CategoryHandlers(
        IAddCategoryCommandHandler addHandler,
        IGetCategoryByIdQueryHandler getByIdHandler,
        IGetCategoriesQueryHandler getHandler,
        IDeleteCategoryCommandHandler deleteHandler,
        IUpdateCategoryCommandHandler updateHandler)
    {
        AddHandler = addHandler;
        GetByIdHandler = getByIdHandler;
        GetHandler = getHandler;
        DeleteHandler = deleteHandler;
        UpdateHandler = updateHandler;
    }

    public IAddCategoryCommandHandler AddHandler { get; }
    public IUpdateCategoryCommandHandler UpdateHandler { get; }
    public IDeleteCategoryCommandHandler DeleteHandler { get; }
    public IGetCategoriesQueryHandler GetHandler { get; }
    public IGetCategoryByIdQueryHandler GetByIdHandler { get; }
}
