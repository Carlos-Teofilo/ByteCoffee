using OrderingContext.Domain.Entities;
using OrderingContext.Infrastructure.Data;

namespace OrderingContext.Infrastructure.UseCases.Create;

public class Repository(AppDbContext context) : OrderingContext.Application.UseCases.Create.Contracts.IRepository
{
    private readonly AppDbContext _context = context;
    public async Task<Order> SaveAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }
}