namespace CatalogContext.Application.DTOs;

public record CreateProductResponse(
    Guid Id,
    string Name,
    string? Description,
    decimal Price);
