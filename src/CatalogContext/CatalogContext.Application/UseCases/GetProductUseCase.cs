using CatalogContext.Application.DTOs;
using CatalogContext.Domain.Entities;
using CatalogContext.Domain.Repositories;

namespace CatalogContext.Application.UseCases;

public class GetProductUseCase(
    IProductRepository repository)
{
    private readonly IProductRepository _repository = repository;

    public async Task<PagedProductReponse> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(cancellationToken);
        
        return new PagedProductReponse(products);
    }

    public async Task<DetailProductResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(id, cancellationToken);

        return product is null
            ? null
            : new DetailProductResponse(product.Id, product.Name, product.Description, product.Price, product.CreatedAt, product.UpdatedAt);
    }
}
