using CatalogContext.Domain.Entities;
using CatalogContext.Infrastructure.Data;

namespace CatalogContext.Infrastructure.UseCases.Create;

public class Repository(AppDbContext context)
    : CatalogContext.Application.UseCases.Create.Contracts.IRepository
{
    
    private readonly AppDbContext _context = context;
    
    public async Task SaveAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken); 
    }
}