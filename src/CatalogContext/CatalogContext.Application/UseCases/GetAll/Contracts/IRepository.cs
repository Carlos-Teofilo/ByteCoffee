using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatalogContext.Domain.Entities;

namespace CatalogContext.Application.UseCases.GetAll.Contracts;

public interface IRepository
{
    Task<(List<Product> Items, int Total)> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken);
}