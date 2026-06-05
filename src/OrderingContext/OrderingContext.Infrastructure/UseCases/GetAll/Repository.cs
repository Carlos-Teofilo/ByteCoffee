using Microsoft.EntityFrameworkCore;
using OrderingContext.Domain.Entities;
using OrderingContext.Infrastructure.Data;

namespace OrderingContext.Infrastructure.UseCases.GetAll;

public class Repository(AppDbContext context) : OrderingContext.Application.UseCases.GetAll.Contracts.IRepository
{
    private readonly AppDbContext _context = context;

    public async Task<(IEnumerable<Order> Orders, int Total)> GetAllAsync(
        int page, int pageSize, CancellationToken cancellationToken)
    {
        var total = await _context.Orders.CountAsync(cancellationToken);
        var orders = await _context.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        return (orders, total);
    }
}
