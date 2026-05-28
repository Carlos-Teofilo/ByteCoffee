using CatalogContext.Application.DTOs;
using CatalogContext.Domain.Entities;
using CatalogContext.Domain.Repositories;

namespace CatalogContext.Application.UseCases;

public class CreateProductUseCase(
    IProductRepository repository)
{
    private readonly IProductRepository _repository = repository;

    public async Task<CreateProductResponse> ExecuteAsync(
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        Product product;
        
        try
        { 
            product = await _repository.CreateAsync(
                new Product(request.Name, request.Description, request.Price),
                cancellationToken);
        }
        catch
        {
            throw new Exception("Failed to create product");
        }

        return new CreateProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price);
    }
}
