using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.UseCases.GetAll.Contracts;

public interface IRepository
{
    Task<(IEnumerable<Order> Orders, int Total)> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken);
}
