using Application.Interfaces;

namespace Application.Features.Wrapper;
public class ProductHandlers : IProductHandlers
{
    public ProductHandlers(
        IAddProductCommandHandler addHandler,
        IDeleteProductCommandHandler deleteHandler,
        IUpdateProductCommandHandler updateHandler,
        IGetProductsQueryHandler getHandler,
        IGetProductByIdQueryHandler getByIdHandler)
    {
        AddHandler = addHandler;
        DeleteHandler = deleteHandler;
        UpdateHandler = updateHandler;
        GetHandler = getHandler;
        GetByIdHandler = getByIdHandler;
    }

    public IAddProductCommandHandler AddHandler { get; }
    public IDeleteProductCommandHandler DeleteHandler { get; }
    public IUpdateProductCommandHandler UpdateHandler { get; }
    public IGetProductsQueryHandler GetHandler { get; }
    public IGetProductByIdQueryHandler GetByIdHandler { get; }

}
