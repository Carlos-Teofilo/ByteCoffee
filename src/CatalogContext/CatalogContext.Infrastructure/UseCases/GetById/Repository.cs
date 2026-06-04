using CatalogContext.Domain.Entities;
using CatalogContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogContext.Infrastructure.UseCases.GetById;

public class Repository(AppDbContext context) : CatalogContext.Application.UseCases.GetById.Contracts.IRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}