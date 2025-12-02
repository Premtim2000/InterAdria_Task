using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product?> Add(Product entity)
    {
        var result = await _context.Products.AddAsync(entity).ConfigureAwait(false);

        await _context.SaveChangesAsync();

        return result is not null ? entity : null;
    }

    public async Task<Product> Delete(Guid productId)
    {
        Product? itemToDelete = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId).ConfigureAwait(false);

        if (itemToDelete is null)
        {
            return null;
        }

        _context.Remove(itemToDelete);

        await _context.SaveChangesAsync();

        return itemToDelete;
    }

    public async Task<IEnumerable<Product>> Get(int pageNumber, int pageSize, string minMax)
    {
        IQueryable<Product> query = _context.Products
        .Include(p => p.Category)
        .AsNoTracking();

        bool orderByMin = minMax?.ToLower() == "min";

        query = orderByMin
            ? query.OrderBy(p => p.Price)
            : query.OrderByDescending(p => p.Price);

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<Product> GetById(Guid productId)
    {
        var result = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == productId);

        return result!;
    }

    public async Task<Product> Update(Product product)
    {
        var foundProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
       
        if (foundProduct == null)
        {
            return null;
        }

        _context.Products.Entry(foundProduct).CurrentValues.SetValues(product);

        await _context.SaveChangesAsync();

        return foundProduct;
    }
}
