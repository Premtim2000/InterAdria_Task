using System.Linq.Expressions;
using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class LoginRepository : ILoginRepository
{
    private readonly UserContext _userContext;
    public LoginRepository(UserContext userContext)
    {
        _userContext = userContext;
    }
    public async Task<User?> GetByUsername(string username)
    {
        return await _userContext.User.FirstOrDefaultAsync(u => u.Username == username).ConfigureAwait(false);
    }
    public async Task<IEnumerable<User>> GetAsync(Expression<Func<User, bool>> predicate)
    {
        return await
                _userContext.User
                    .Where(predicate)
                    .ToListAsync()
                    .ConfigureAwait(false);
    }

    public async Task<User> Add(User user)
    {
        var result = await _userContext.User.AddAsync(user);

        await _userContext.SaveChangesAsync();

        return result is not null ? user : null;
    }
}
