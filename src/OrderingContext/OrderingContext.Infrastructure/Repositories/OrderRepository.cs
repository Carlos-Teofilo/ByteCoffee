using Microsoft.EntityFrameworkCore;
using OrderingContext.Domain.Entities;
using OrderingContext.Domain.Repositories;
using OrderingContext.Infrastructure.Data;

namespace OrderingContext.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<Order> AddAsync(Order aggregate, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(aggregate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return aggregate;
    }

    public async Task<Order?> GetByIdAsync(int id, Guid customerId, CancellationToken cancellationToken)
        => await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == id && x.CustomerId == customerId, cancellationToken);
    
    public async Task<(int, IReadOnlyCollection<Order>)> GetAllAsync(Guid customerId, CancellationToken cancellationToken)
    {
        var total = await _context.Orders.CountAsync(x => x.CustomerId == customerId, cancellationToken);
        
        var orders = await _context.Orders
            .Where(x => x.CustomerId == customerId)
            .Include(o => o.OrderItems)
            .ToListAsync(cancellationToken);  
        
        // 🟢 Retorno envelopado com parênteses
        return (total, orders);
    }
}