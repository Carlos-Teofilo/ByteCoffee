using CatalogContext.Domain.Entities;

namespace CatalogContext.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken);
    
}
