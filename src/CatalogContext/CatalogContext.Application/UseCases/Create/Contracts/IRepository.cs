using System.Threading;
using System.Threading.Tasks;
using CatalogContext.Domain.Entities;

namespace CatalogContext.Application.UseCases.Create.Contracts;

public interface IRepository
{
    Task SaveAsync(Product product, CancellationToken cancellationToken);
}