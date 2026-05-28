using CatalogContext.Domain.Entities;
using CatalogContext.Domain.Repositories;
using CatalogContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogContext.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
}
