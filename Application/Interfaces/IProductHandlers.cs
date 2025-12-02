namespace Application.Interfaces;
public interface IProductHandlers
{
    IAddProductCommandHandler AddHandler { get; }
    IDeleteProductCommandHandler DeleteHandler { get; }
    IUpdateProductCommandHandler UpdateHandler { get; }
    IGetProductsQueryHandler GetHandler { get; }
    IGetProductByIdQueryHandler GetByIdHandler { get; }
}
