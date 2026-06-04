using CatalogContext.Domain.Entities;
using CatalogContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CatalogContext.Infrastructure.UseCases.GetAll;

public class Repository(AppDbContext context) : CatalogContext.Application.UseCases.GetAll.Contracts.IRepository
{
    private readonly AppDbContext _context = context;

    public async Task<(List<Product> Items, int Total)> GetAllAsync(
        int page = 0, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var total = await _context.Products.CountAsync(cancellationToken);
        var products = await _context.Products
            .Skip(page * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return (products, total);
    } 
}