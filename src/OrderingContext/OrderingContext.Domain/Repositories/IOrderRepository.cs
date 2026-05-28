using OrderingContext.Domain.Entities;
using OrderingContext.Domain.Interfaces;

namespace OrderingContext.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order> AddAsync(Order aggregate, CancellationToken cancellationToken);

    Task<Order?> GetByIdAsync(int id, Guid customerId, CancellationToken cancellationToken);

    Task<(int, IReadOnlyCollection<Order>)> GetAllAsync(Guid customerId, CancellationToken cancellationToken); 
}
