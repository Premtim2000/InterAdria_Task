using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly ProductContext _context;
    public CategoryRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Category?> Add(Category entity)
    {
        var result = await _context.Category.AddAsync(entity).ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return result is not null ? entity : null;
    }

    public async Task<Category> Delete(Guid id)
    {
        Category? itemToDelete = await _context.Category.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

        if (itemToDelete is null)
        {
            return null;
        }

        _context.Category.Remove(itemToDelete);

        await _context.SaveChangesAsync();

        return itemToDelete;
    }

    public async Task<IEnumerable<Category>> Get(int pageNumber, int pageSize)
    {
        IQueryable<Category> query = _context.Category
        .AsNoTracking();

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<Category> GetById(Guid id)
    {
        var result = await _context.Category.FirstOrDefaultAsync(p => p.Id == id);

        return result!;
    }

    public async Task<Category> Update(Category category)
    {
        var foundCategory = await _context.Category.FirstOrDefaultAsync(p => p.Id == category.Id);

        if (foundCategory == null)
        {
            return null;
        }

        _context.Category.Entry(foundCategory).CurrentValues.SetValues(category);

        await _context.SaveChangesAsync();

        return foundCategory;
    }
}
