using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.UseCases.Create.Contracts;

public interface IRepository
{
    Task<Order> SaveAsync(Order order, CancellationToken cancellationToken);
}