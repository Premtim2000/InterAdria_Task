using Core.Entities;

namespace Core.Repository;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> Get(int pageNumber, int pageSize);
    Task<Category> GetById(Guid productId);
    Task<Category> Add(Category product);
    Task<Category> Delete(Guid productId);
    Task<Category> Update(Category product);
}
