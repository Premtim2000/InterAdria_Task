namespace Application.Interfaces;
public interface ICategoryHandlers
{
    IAddCategoryCommandHandler AddHandler { get; }
    IGetCategoryByIdQueryHandler GetByIdHandler { get; }
    IGetCategoriesQueryHandler GetHandler { get; }
    IDeleteCategoryCommandHandler DeleteHandler { get; }
    IUpdateCategoryCommandHandler UpdateHandler { get; }
}
