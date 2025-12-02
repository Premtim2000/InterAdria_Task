using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repository;
public interface ILoginRepository
{
    Task<User?> GetByUsername(string username);
    Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>> predicate);
    Task<User> Add(User user);
}
