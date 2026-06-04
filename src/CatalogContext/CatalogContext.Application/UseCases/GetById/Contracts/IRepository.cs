using CatalogContext.Domain.Entities;

namespace CatalogContext.Application.UseCases.GetById.Contracts;

public interface IRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
