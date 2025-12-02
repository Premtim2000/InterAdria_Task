using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repository;
public interface IProductRepository
{
    Task<IEnumerable<Product>> Get(int pageNumber, int pageSize, string minMax);
    Task<Product> GetById(Guid productId);
    Task<Product> Add(Product product);
    Task<Product> Delete(Guid productId);
    Task<Product> Update(Product product);
}
